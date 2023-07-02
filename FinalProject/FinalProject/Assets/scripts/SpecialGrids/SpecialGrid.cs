using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class SpecialGrid : MonoBehaviour
{

    protected playerGridMovement _playerGridMovement;
    protected Dice _dice;

    private void Start()
    {
        _playerGridMovement = GameObject.FindWithTag("Player").GetComponent<playerGridMovement>();
        _dice = GameObject.FindWithTag("Dice").GetComponent<Dice>();
    }

    protected void ActivateEffect()
    {

    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ActivateEffect();
        }
    }
}
