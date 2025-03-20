using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemy : MonoBehaviour
{
    public GameManager GameManager;

    public Vector3 Enemy_1()
    {
        if (GameManager.GameStop == false)
        {
            float Speed = 10f;
            return new Vector3(0, 0, Speed);
        }
        else
        {
            return new Vector3(0, 0, 0);
        } 
    }
    public Vector3 Enemy_2()
    {
        if (GameManager.GameStop == false)
        {
            float Speed = 10f;
            return new Vector3(0, 0, Speed);
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }
    public Vector3 Enemy_3()
    {
        if (GameManager.GameStop == false)
        {
            float Speed = 10f;
            return new Vector3(0, 0, Speed);
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }
    public Vector3 Enemy_4()
    {
        if(GameManager.GameStop == false)
        {
            float Speed = 10f;
            return new Vector3(0, 0, Speed);
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }
}
