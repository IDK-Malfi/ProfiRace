using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLeftMove : MonoBehaviour
{
    private Rigidbody rb;
    Player player;
    GameManager GameManager;
    public RoadLeftManager RoadPool;
    void Start()
    {
        RoadPool = FindObjectOfType<RoadLeftManager>();
        rb = GetComponent<Rigidbody>();
        player = FindAnyObjectByType<Player>();
        GameManager = FindAnyObjectByType<GameManager>();
    }
    public float Move_1()
    {
        if (GameManager.GameStop == false)
        {
            float Speed = 10f * player.SpeedUpBuster * GameManager.AllSpeed;// Умножаем на AllSpeed для увелечения скорости
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
        if (other.CompareTag("Trigger"))
        {
            float PosX = transform.position.x;
            if (PosX == -7.6f)
            {
                RoadPool.SpawnLeft();
                gameObject.SetActive(false);
            }
        }
    }
}
