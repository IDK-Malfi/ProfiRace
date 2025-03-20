using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    private Rigidbody rb;
    Player player;
    GameManager GameManager;
    CarManager CarManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindAnyObjectByType<Player>();
        GameManager = FindAnyObjectByType<GameManager>();
        CarManager = FindAnyObjectByType<CarManager>();

    }
    public float Move_1()
    {
        if (GameManager.GameStop == false)
        {
            float Speed = 40f;
            return Speed * player.SpeedUpBuster * GameManager.AllSpeed;// Умножаем на AllSpeed для увелечения скорости
        }
        return 0f;
    }
    void Update()
    {
        rb.velocity = -new Vector3(0, 0, Move_1());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            float PosX = transform.position.x;
            if (PosX == -5.8f)
            {
                CarManager.CarSpawnRight();
                gameObject.SetActive(false);
            }
            else if (PosX == -9f)
            {
                CarManager.CarSpawnLeft();
                gameObject.SetActive(false);
            }
        }
    }
}
