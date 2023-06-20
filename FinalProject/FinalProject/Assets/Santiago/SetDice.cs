using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SetDice : MonoBehaviour
{
    public GameObject diceSpawnSpot;
    public GameObject dicePrefab;
    private int diceSetted;
    public void SetNewDice()
    {
        if (diceSetted < 1)
        {
            Instantiate(dicePrefab, diceSpawnSpot.transform, false);
            diceSetted += 1;
        }
    }
}
