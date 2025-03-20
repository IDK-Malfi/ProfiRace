using UnityEngine;

public class CellManager : MonoBehaviour
{
    public GameObject[] CellPool;
    public GameObject[] ParkCellPool;
    public Vector3 Right;
    public int indexHome;
    public int indexPark;
    public GameObject CellChangeEnter;
    public GameObject CellChangeExit;
    private void Start()
    {
        indexHome = Random.Range(5, 30);
    }
    public void SpawnRight()
    {
        GameObject spawn = null;
        if (indexHome >= 0)
        {
            if (indexHome == 0)
            {
                indexPark = Random.Range(5, 30);
                spawn = CellChangeEnter;
                spawn.transform.position = Right;
                spawn.SetActive(true);
            }                   
            else
            {
                spawn = Homepoolcell();
                if (spawn != null)
                {
                    spawn.transform.position = Right;
                    spawn.SetActive(true);
                }
            }         
        }
        else if (indexPark >= 0)
        {
            if (indexPark == 0)
            {
                indexHome = Random.Range(20, 30);
                spawn = CellChangeExit;
                spawn.transform.position = Right;
                spawn.SetActive(true);
            }        
            else
            {
                spawn = Parkpool();
                if (spawn != null)
                {
                    float ScaleX = RandomScaleX();
                    float ScaleZ = RandomScaleZ();
                    spawn.transform.position = Right;
                    spawn.transform.localScale = new Vector3(ScaleX, 1.2f, ScaleZ);
                    spawn.SetActive(true);
                }
            }
        }
    }
    float RandomScaleX()
    {
        int randomIndex = Random.Range(0, 2);
        return randomIndex == 0 ? 1.2f : -1.2f;
    }
    float RandomScaleZ()
    {
        int randomIndex = Random.Range(0, 2);
        return randomIndex == 0 ? 1.4f : -1.4f;
    }
    GameObject Homepoolcell() 
    {
        int randomCell = Random.Range(0, CellPool.Length);
        if (CellPool[randomCell].activeInHierarchy == false) 
        {
            return CellPool[randomCell];
        }
        else
        {
            for(int i = 0; i < CellPool.Length; i++)
            {
                if (CellPool[i].activeInHierarchy == false)
                    return CellPool[i];
            }
        }
        return null;
    }
    GameObject Parkpool()
    {
        int randomCell = Random.Range(0, ParkCellPool.Length);
        if (ParkCellPool[randomCell].activeInHierarchy == false)
        {
            return ParkCellPool[randomCell];
        }
        else
        {
            for (int i = 0; i < ParkCellPool.Length; i++)
            {
                if (ParkCellPool[i].activeInHierarchy == false)
                    return ParkCellPool[i];
            }
        }
        return null;
    }
}
