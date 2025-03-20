using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform[] EnemyTransform;
    public GameObject[] AllPool;
    public GameObject[] Money;
    public GameObject StartGame;
    public GameObject GameSetting;
    public GameObject GameStatus;
    public GameObject GameOver;
    public GameObject MiniGame;
    public GameObject Menu;
    public GameObject Counter;
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI Vopros;
    public TextMeshProUGUI[] Otvet;
    public Button[] buttons;
    public bool GameStop;
    public Animator animator;
    public int CounterInt;
    public TextMeshProUGUI CounterText;
    Player player;
    public float AllSpeed;
    private void Start()
    {
        StartCoroutine(SpawnTime());
        player = FindAnyObjectByType<Player>();
    }

    private void Update() //Создаем глобальную переменную AllSpeed которая будет ускорять скорость игрока по достижению определнного счета
    {
        CounterText.text = CounterInt.ToString();
        if(CounterInt >= 150)
        {
            AllSpeed = 1.5f;
        }
        if(CounterInt >= 300)
        {
            AllSpeed = 2;
        }
    }

    IEnumerator SpawnTime()
    {
        while (true)
        {
            if (!GameStop)
            {
                Spawn();
                yield return new WaitForSeconds(1.5f);
            }
            else
            {
                yield return null;
            }
        }
    }
    public void Spawn()
    {
        int random = Random.Range(0, 100);
        if (random >= 50)
        {
            GameObject gameObject = SpawnFromPool_0();
            if (gameObject != null)
            {
                gameObject.transform.position = new Vector3(EnemyTransform[Random.Range(0, EnemyTransform.Length)].position.x, gameObject.transform.position.y, EnemyTransform[1].position.z);
                gameObject.SetActive(true);
            }
        }
        else
        {
            GameObject gameObject = SpawnFromPool_1();
            if (gameObject != null)
            {
                gameObject.transform.position = new Vector3(EnemyTransform[Random.Range(0, EnemyTransform.Length)].position.x, gameObject.transform.position.y, EnemyTransform[1].position.z);
                gameObject.SetActive(true);
            }
        }
    }
    GameObject SpawnFromPool_0()
    {
        for (int i = 0; i < AllPool.Length; i++)
        {
            if (!AllPool[i].activeInHierarchy)
            {
                return AllPool[i];
            }
        }
        return null;
    }
    GameObject SpawnFromPool_1()
    {
        for (int i = 0; i < Money.Length; i++)
        {
            if (!Money[i].activeInHierarchy)
            {
                return Money[i];
            }
        }
        return null;
    }
    void GameOverSetFals()
    {
        for(int i = 0; i < AllPool.Length; i++)
        {
            AllPool[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < Money.Length; i++)
        {
            Money[i].gameObject.SetActive(false);
        }
    }
    public void DeactivateObject(GameObject gameObject)
    {
        gameObject.SetActive(false);      
    }
    public void CanvasStartGame()
    {
        textMeshProUGUI.text = 0.ToString();
        StartGame.SetActive(false);    
        animator.Play("CameraAnimation");
        Invoke("CanvasMenu", 1f);
    }
    void CanvasMenu()
    {
        Menu.SetActive(true);
    }
    public void PlayGame()
    {
        Menu.SetActive(false);
        GameStatus.SetActive(true);
        GameStop = false;
        animator.Play("ExiteCamera");
    }
    public void CanvasGameSetting()
    {
        StartGame.SetActive(false);
        GameSetting.SetActive(true);
    }
    public void CanvasMiniGame()
    {
        MiniGame.SetActive(true);
        GameStop = true;
        CreateVopros();
    }
    public void CanvasGameOver()
    {
        GameStop = true;
        GameOver.SetActive(true);
        GameOverSetFals();
        CounterInt = 0;
        AllSpeed = 0.8f; //При проигрыше возращаем значение переменной AllSpeed на начальную
    }
    public void ResetGame()
    {
        GameStatus.SetActive(false);
        GameOver.SetActive(false);
        StartGame.SetActive(true);
    }
    void CreateVopros()
    {
        int random = Random.Range(1, 4);
        Vopros.text = AllVopros(random);
        for (int i = 0; i < Otvet.Length; i++)
        {
            Otvet[i].text = AllOtvet(random);
            buttons[i].onClick.AddListener(GoodStartGame);
        }
        int random1 = Random.Range(0, Otvet.Length);
        int random2 = Random.Range(0, 100);
        Otvet[random1].text = random2.ToString();
        buttons[random1].onClick.AddListener(BadStartGame);
    }
    string AllVopros(int random)
    { 
        string vopros = null;
        switch (random)
        {
            case 1:
                vopros = "2 + 2 = ?";
                return vopros;
            case 2:
                vopros = "2 + 4 = ?";
                return vopros;
            case 3:
                vopros = "2 + 6 = ?";
                return vopros;
            case 4:
                vopros = "2 + 8 = ?";
                return vopros;
        }
        return null;
    }
    string AllOtvet(int random)
    {
        string otvet = null;
        switch (random)
        {
            case 1:
                otvet = "4";
                return otvet;
            case 2:
                otvet = "6";
                return otvet;
            case 3:
                otvet = "8";
                return otvet;
            case 4:
                otvet = "10";
                return otvet;
        }
        return null;
    }
    public void GoodStartGame()
    {
        MiniGame.SetActive(false);
        GameStop = false;
        buttons[0].onClick.RemoveAllListeners();
        buttons[1].onClick.RemoveAllListeners();
    }
    public void BadStartGame()
    {
        CanvasGameOver();
    }   
    public void Back()
    {
        StartGame.SetActive(true);
        GameSetting.SetActive(false);
    }
}
