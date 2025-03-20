using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    private Vector2 touchStartPosition;
    private float minSwipeDistance = 25f;
    private float swipeCooldown = 0.05f; // Задержка между свайпами
    private bool canSwipe = true; // Флаг, позволяющий свайпать
    public Vector3[] TransformTriger;
    int count = 1;
    float smoothSpeed;
    private bool isMoving = false;
    GameManager GameManager;
    public GameObject CanvasGameOver;
    public float SpeedUpBuster;
    public float JumpUpBuster;
    bool CanLeftRight = true;
    public Animator animator;
    bool isJumping = false;
    float jumpStartTime;
    private void Start()
    {
        SpeedUpBuster = 0.8f;
        rb = GetComponent<Rigidbody>();
        GameManager = FindObjectOfType<GameManager>();
        smoothSpeed = 25f;
        JumpUpBuster = 1;
        animator.Play("rig|БЕГ");
    }
    void Update()
    {
        MovePlayer();
        Keyboard();
        if (isJumping)
        {               
            PerformJump();
        }
    }
    void MovePlayer()
    {
        if (!GameManager.GameStop)
        {
            if (isMoving || !canSwipe) // Добавляем проверку на флаг canSwipe
            {
                return;
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    if (isMoving)
                    {
                        return;
                    }
                    Vector2 swipeDelta = touch.position - touchStartPosition;
                    if (swipeDelta.magnitude > minSwipeDistance)
                    {
                        if (swipeDelta.x < 0 && (Mathf.Abs(swipeDelta.x) > swipeDelta.y))
                        {
                            if (count == 0)
                            {
                                return;
                            }
                            count -= 1;
                            StartCoroutine(SmoothMove(TransformTriger[count]));
                            Debug.Log("Swipe Left");
                        }
                        else if (swipeDelta.x > 0 && (Mathf.Abs(swipeDelta.x) > swipeDelta.y))
                        {
                            if (count == 2)
                            {
                                return;
                            }
                            count += 1;
                            StartCoroutine(SmoothMove(TransformTriger[count]));
                            Debug.Log("Swipe Right");
                        }
                        else if (swipeDelta.y > 0)
                        {
                            if (!isJumping)
                            {
                                StartJump();
                            }
                        }
                    }
                }
            }
        }
    }
    void StartJump()
    {
        isJumping = true;     
        jumpStartTime = Time.time;
        animator.Play("rig|ПРЫЖОК НАЧАЛО");
    }
    void PerformJump()
    {
        float jumpDuration = 0.7f;
        float timeSinceJumpStart = Time.time - jumpStartTime;
        if (timeSinceJumpStart <= jumpDuration)
        {
            float jumpProgress = timeSinceJumpStart / jumpDuration;
            float jumpHeightValue = Mathf.Sin(jumpProgress * Mathf.PI) * 3f * JumpUpBuster;
            transform.position = new Vector3(transform.position.x, jumpHeightValue + 0.8f, transform.position.z);
            animator.Play("rig|ПРЫЖОК_ПОЛЕТ");
        }
        else
        {          
            isJumping = false;
            animator.Play("rig|БЕГ");
        }
    }
    void Keyboard()
    {
        if (rb.position.x >= -1 || rb.position.x <= 0)
        {
            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && CanLeftRight)
            {
                if (count == 2)
                {
                    return;
                }
                count += 1;
                StartCoroutine(SmoothMove(TransformTriger[count]));
                Debug.Log("Right");
                CanLeftRight = false;
            }

        }
        if (rb.position.x <= 1 || rb.position.x >= 0)
        {
            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && CanLeftRight)
            {
                if (count == 0)
                {
                    return;
                }
                count -= 1;
                StartCoroutine(SmoothMove(TransformTriger[count]));
                Debug.Log("Left");
                CanLeftRight = false;
            }

        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && CanLeftRight && !isJumping)
        {
            StartJump();
        }

    }
    IEnumerator SmoothMove(Vector3 targetPosition)
    {
        isMoving = true;
        canSwipe = false; // Блокируем свайпы на время движения
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false; // Добавляем задержку между свайпами
        canSwipe = true; // Разблокируем свайпы
        CanLeftRight = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            int currentValue = int.Parse(GameManager.textMeshProUGUI.text);
            int numberToAdd = 1;
            int result = currentValue + numberToAdd;
            GameManager.textMeshProUGUI.text = result.ToString();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            GameManager.CanvasMiniGame();
        }
        if (other.gameObject.CompareTag("SpeedUp"))
        {
            other.gameObject.SetActive(false);
            StartCoroutine(Busster());
        }
        if (other.gameObject.CompareTag("JumpBust"))
        {
            other.gameObject.SetActive(false);
            StartCoroutine(UpBust());
        }
    }
    IEnumerator Busster()
    {
        SpeedUpBuster = 1.6f;
        yield return new WaitForSeconds(10f);
        SpeedUpBuster = 0.8f;
    }
    IEnumerator UpBust()
    {
        JumpUpBuster = 1.2f;
        yield return new WaitForSeconds(10f);
        JumpUpBuster = 1;
    }
}