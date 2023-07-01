using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class destroyClones : MonoBehaviour
{
    private CreateDice _createDice;
    private void Start()
    {
        _createDice = GameObject.FindWithTag("Finish").GetComponent<CreateDice>();
        _createDice.craftedDice = false;
    }

    private void Update()
    {
        Destroy();
    }

    private void Destroy()
    {
        if (_createDice.craftedDice == true)
        {
            Destroy(gameObject);
        }
    }
}
