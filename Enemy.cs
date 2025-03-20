using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AllEnemy
{
    Rigidbody rb;
    Player player;
    private void Start()
    {
        GameManager = FindAnyObjectByType<GameManager>();
        rb = GetComponent<Rigidbody>();
        player = FindAnyObjectByType<Player>();
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        rb.velocity = -Enemy_1() * player.SpeedUpBuster * GameManager.AllSpeed; // Умножаем на AllSpeed для увелечения скорости
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OffObjects"))
        {
            GameObject gameObject = this.gameObject;
            GameManager.DeactivateObject(gameObject);
        }
    }
}