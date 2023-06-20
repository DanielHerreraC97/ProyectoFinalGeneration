using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialStart : MonoBehaviour
{
  public int diceElection;
  public GameObject diceSpawnSpot;
  public GameObject dicePrefab;
  private void Awake()
  {
    if (diceElection == 1)
    {
      Instantiate(dicePrefab, diceSpawnSpot.transform, false);
    }
  }
}
