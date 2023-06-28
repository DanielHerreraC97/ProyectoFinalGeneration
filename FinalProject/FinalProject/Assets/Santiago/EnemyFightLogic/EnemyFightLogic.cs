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

    private static int ConditiontoWin;


    public Animator enemyAnimator;
    public Animator playerAnimator;
    private bool PlayerDeath = false;
    private bool EnemyDeath = false;

    private void Start()
    {
        _playerGridMovement = GameObject.FindWithTag("Player").GetComponent<playerGridMovement>();
    }
    private void Update()
    {
        enemyEnergy = GetComponent<EnemyGridMovemtn>().recall;

        Debug.Log("enemigos muertos: " + ConditiontoWin);
        if (ConditiontoWin == 4)
        {
            SceneManager.LoadScene(5);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EnemyDeath = false;
            if (_playerGridMovement.recall > enemyEnergy)
            {
                // enemyEnergy -= _playerGridMovement.recall;
                // Destroy(gameObject,5f);
                Debug.Log("player win");
                //this.gameObject.SetActive(false);
                ConditiontoWin++;
                EnemyDeath = true;
                StartCoroutine(WaitForDeathAnimation());
            }

            if (_playerGridMovement.recall <= enemyEnergy)
            {
                //collision.gameObject.SetActive(false);
                //Destroy(other.gameObject,5f);
                Debug.Log("Player lose");
                //SceneManager.LoadScene(2);
                PlayerDeath = true;
                StartCoroutine(WaitForDeathAnimation());
            }
        }
    }

    private IEnumerator WaitForDeathAnimation()
    {
        if (EnemyDeath == true)
        {
            enemyAnimator.SetTrigger("IsDeath");
            float tiempoEsperaE = 2.0f;
            yield return new WaitForSecondsRealtime(tiempoEsperaE);
            gameObject.SetActive(false);
        }

        if (PlayerDeath == true)
        {
            playerAnimator.SetTrigger("IsDeath");
            float tiempoEsperaP = 2.0f;
            yield return new WaitForSecondsRealtime(tiempoEsperaP);
            SceneManager.LoadScene(4);
        }
    }
}