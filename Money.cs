using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : AllEnemy
{
    Rigidbody rb;
    Player player;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager = FindAnyObjectByType<GameManager>();
        player = FindAnyObjectByType<Player>();
    }
    void Update()
    {
        rb.velocity = -Enemy_1() * player.SpeedUpBuster * GameManager.AllSpeed;// Умножаем на AllSpeed для увелечения скорости
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
