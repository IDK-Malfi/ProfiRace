using UnityEngine;

public class Busters : AllEnemy
{
    RoadManager _RM;
    Rigidbody rb;
    public GameObject SpeedUp;
    Player player;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager = FindAnyObjectByType<GameManager>();
        player = FindAnyObjectByType<Player>();
    }

    private void Update()
    {
        rb.velocity = -Enemy_1() * player.SpeedUpBuster;
    }
}
