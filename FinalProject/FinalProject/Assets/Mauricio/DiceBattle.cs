using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

/*public class DiceBattle : MonoBehaviour
{

    public Canvas DB_Background;
    private playerGridMovement PlayerGridMovement; // Referencia al objeto del dado
    private EnemyGridMovemtn enemyGridMovement; // Referencia al objeto del dado
    public Transform playerRenderer; // Referencia al componente SpriteRenderer del dado
    public Transform enemyRenderer; // Referencia al componente SpriteRenderer del dado
    private SpriteRenderer SpritePlayer;
    private SpriteRenderer SpriteEnemy;
    private Animation AnimationEnemy;


    private void Awake()
    {
        SpritePlayer = playerRenderer.GetComponent<SpriteRenderer>();
        SpriteEnemy = enemyRenderer.GetComponent<SpriteRenderer>();

        AnimationEnemy = enemyRenderer.GetComponent<Animation>();

        DB_Background.enabled = false;
        SpritePlayer.enabled = true;
        SpriteEnemy.enabled = true;
    }

    private void Start()
    {
       
    }

    public void Battle()
    {
        DB_Background.enabled = true;
        if(PlayerGridMovement.recall > enemyGridMovement.recall)
        {
            // Animaci�n del objeto 1 (movimiento y retorno)
            playerRenderer.DOMove(enemyRenderer.transform.position, 1f).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                playerRenderer.DOMove(transform.position, 1f).SetEase(Ease.OutQuad);
            });

            // Animaci�n del objeto 2 (temblor y animaci�n adicional)
            enemyRenderer.DOShakePosition(1f, 0.5f, 10, 90f, false, true).OnComplete(() =>
            {
                AnimationEnemy.Play();
                // Aqu� puedes utilizar otra funci�n de animaci�n de DoTween
            });
        }
        else
        {
            Debug.Log("Perdiste");
            DB_Background.enabled = false;
        }
    }

}*/

public class DiceBattle : MonoBehaviour
{
    public playerGridMovement playerGridMovement;
    public EnemyGridMovemtn enemyGridMovement;
    public GameObject enemyObject;
    public Image diceObject;
    public string restartSceneName;

    public void Battle()
    {
        int playerRecall = playerGridMovement.recall;
        int enemyRecall = enemyGridMovement.recall;

        if (playerRecall > enemyRecall)
        {
            enemyObject = null;
            diceObject = null;
        }
        else
        {
            // Reiniciar la escena
            SceneManager.LoadScene(restartSceneName);
        }
    }
}


