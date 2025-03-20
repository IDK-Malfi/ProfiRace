using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSkyBoxMove : MonoBehaviour
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
        if (other.CompareTag("TriggerSkyBox"))
        {
            this.gameObject.transform.position = new Vector3(-18f, 0, 95f);
        }
    }
}
