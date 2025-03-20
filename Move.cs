using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 Speed;
    public CellManager CellPool;
    Player player;
    GameManager gameManager;
    void Start()
    {
        CellPool = FindObjectOfType<CellManager>();
        rb = GetComponent<Rigidbody>();
        player = FindAnyObjectByType<Player>();
        gameManager = FindAnyObjectByType<GameManager>();
    }
    public float Move_1()
    {
        if (gameManager.GameStop == false)
        {
            float Speed = 10f * player.SpeedUpBuster * gameManager.AllSpeed;// Умножаем на AllSpeed для увелечения скорости
            return Speed;
        }
        return 0f;
    }    
    void Update()
    {
        rb.velocity = -new Vector3(0, 0, Move_1());
    }
    private void OnTriggerEnter(Collider other)
    {
        float PosX = transform.position.x;
        if (other.CompareTag("Trigger"))
        {
            gameManager.CounterInt++;
            gameObject.SetActive(false);
            CellPool.indexHome--;
            CellPool.indexPark--;
            CellPool.SpawnRight();
        }
    }
}
