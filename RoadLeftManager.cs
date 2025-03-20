using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLeftManager : MonoBehaviour
{
    public GameObject[] RoadPool;
    public Vector3 Left;
    public void SpawnLeft()
    {
        GameObject spawn = Homepool();
        if (spawn != null)
        {
            spawn.transform.position = Left;
            spawn.SetActive(true);
        }
        else
        {
            SpawnLeft();
        }
    }
    GameObject Homepool()
    {
        int randomRoad = Random.Range(0, RoadPool.Length);
        if (RoadPool[randomRoad].activeInHierarchy == false)
        {
            return RoadPool[randomRoad];
        }
        return null;
    }
}
