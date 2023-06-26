using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyFightLogic : MonoBehaviour
{
    public int enemyEnergy;
    private playerGridMovement _playerGridMovement;

    private void Start()
    {
        _playerGridMovement = GameObject.FindWithTag("Player").GetComponent<playerGridMovement>();
    }
    private void Update()
    {
        enemyEnergy = GetComponent<EnemyGridMovemtn>().recall;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_playerGridMovement.recall > enemyEnergy)
            {
                // enemyEnergy -= _playerGridMovement.recall;
                // Destroy(gameObject,5f);
                Debug.Log("player win");
                this.gameObject.SetActive(false);
            }

            if (_playerGridMovement.recall <= enemyEnergy)
            {
                collision.gameObject.SetActive(false);
                //Destroy(other.gameObject,5f);
                Debug.Log("Player lose");
            }
        }
    }
}
