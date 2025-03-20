using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoadManager : MonoBehaviour
{
    public Transform RoadTrigger;
    GameManager GameManager;
    Player player;
    [NonSerialized] public float Speed = 10f;
    private void Start()
    {
        GameManager = FindAnyObjectByType<GameManager>();
        player = FindAnyObjectByType<Player>();
    }
    public void SpawnRoad(GameObject gameObject)
    {
        gameObject.transform.position = RoadTrigger.position;
    }
    public Vector3 Road_1()
    {
        if (GameManager.GameStop == false)
        {
            return new Vector3(0, 0, Speed * player.SpeedUpBuster);
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }
}