using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    private Rigidbody rb;
    Player player;
    GameManager GameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindAnyObjectByType<Player>();
        GameManager = FindAnyObjectByType<GameManager>();
    }
    public float Move_1()
    {
        if (GameManager.GameStop == false)
        {
            float Speed = 7f * player.SpeedUpBuster * GameManager.AllSpeed;// Умножаем на AllSpeed для увелечения скорости
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
            this.gameObject.transform.position = new Vector3(Random.Range(-3,6), transform.position.y, 100f);
        }
    }
}