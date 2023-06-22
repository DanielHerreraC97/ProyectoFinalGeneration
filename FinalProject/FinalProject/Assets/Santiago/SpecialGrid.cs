using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialGrid : MonoBehaviour
{
    private playerGridMovement _playerGridMovement;
    private Dice _dice;
    public Animation _Animation;

    private void Start()
    {
        _Animation = GetComponent<Animation>();
        _playerGridMovement = GameObject.FindWithTag("Player").GetComponent<playerGridMovement>();
        _dice = GameObject.FindWithTag("Dice").GetComponent<Dice>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _Animation.Play();
            _playerGridMovement.Punishment();
            Destroy(this.gameObject);
        }
    }
}
