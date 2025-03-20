using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Road : MonoBehaviour
{
    Rigidbody rb;
    RoadManager RoadManager;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        RoadManager = FindAnyObjectByType<RoadManager>();
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        rb.velocity = -RoadManager.Road_1();    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OffObjects"))
        {          
            RoadManager.SpawnRoad(this.gameObject);
        }
    }
}
