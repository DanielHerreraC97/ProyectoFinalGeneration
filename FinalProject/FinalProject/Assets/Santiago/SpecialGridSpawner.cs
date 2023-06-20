using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class SpecialGridSpawner : MonoBehaviour
{
    public GameObject[] specialGrids;
    public GameObject[] gridSpawners;
    private int setGrids;
    public int regulatorSpawner;
    private void Update()
    {
        spawnSpecialGrid();
    }

    private void spawnSpecialGrid()
    {
        if (regulatorSpawner < 1)
        {
            int gridPos = Random.Range(0, 2);
            setGrids = Random.Range(0, 2);
            Instantiate(specialGrids[setGrids],gridSpawners[gridPos].transform.position,
                gridSpawners[gridPos].transform.rotation);
            regulatorSpawner += 1;
        }
    }
}
