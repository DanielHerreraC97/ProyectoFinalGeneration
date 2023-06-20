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
    public TMP_Text energyCount;

    private void Start()
    {
        _playerGridMovement = GameObject.FindWithTag("Player").GetComponent<playerGridMovement>();
    }

    private void Update()
    {
        energyCount.text = enemyEnergy.ToString();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_playerGridMovement.recall > enemyEnergy)
            {
                enemyEnergy -= _playerGridMovement.recall;
                Destroy(gameObject,5f);
            }

            if (_playerGridMovement.recall < enemyEnergy)
            {
                Destroy(other.gameObject,5f);
            }
        }
    }
}
