using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyFightLogic : MonoBehaviour
{
    public int enemyEnergy;
    private playerGridMovement _playerGridMovement;

    private int ConditiontoWin = 0;

    private void Start()
    {
        _playerGridMovement = GameObject.FindWithTag("Player").GetComponent<playerGridMovement>();
    }
    private void Update()
    {
        enemyEnergy = GetComponent<EnemyGridMovemtn>().recall;

        Debug.Log(ConditiontoWin);
        if(ConditiontoWin == 3)
        {
            SceneManager.LoadScene(3);
        }
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
                ConditiontoWin += 1;
            }

            if (_playerGridMovement.recall <= enemyEnergy)
            {
                collision.gameObject.SetActive(false);
                //Destroy(other.gameObject,5f);
                Debug.Log("Player lose");
                SceneManager.LoadScene(2);
            }
        }
    }
}
