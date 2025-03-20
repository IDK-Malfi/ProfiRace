using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public GameObject[] CarPool;
    public Vector3 CarRight;
    public Vector3 CarLeft;

    public void CarSpawnRight()
    {
        GameObject spawn = Homepool();
        if (spawn != null)
        {
            spawn.transform.position = CarRight;
            spawn.SetActive(true);
        }
        else
        {
            CarSpawnRight();
        }
    }
    public void CarSpawnLeft()
    {
        GameObject spawn = Homepool();
        if (spawn != null)
        {
            spawn.transform.position = CarLeft;
            spawn.SetActive(true);
        }
        else
        {
            CarSpawnLeft();
        }
    }
    GameObject Homepool()
    {
        int randomCar = Random.Range(0, CarPool.Length);
        if (CarPool[randomCar].activeInHierarchy == false)
        {
            return CarPool[randomCar];
        }
        return null;
    }
}
