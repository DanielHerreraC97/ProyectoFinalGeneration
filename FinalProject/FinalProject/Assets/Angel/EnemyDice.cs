using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using Unity.Mathematics;

public class EnemyDice : MonoBehaviour
{

    [Tooltip("Sprites de todas las caras del dado + sprite de desactivado. " +
             "El sprite desactivado debe ser #0. " +
             "De resto colocar en casilla correspondiente.")]
    public Sprite[] diceSides;
    private Image rend;
    private int randomDiceSide;

    [Header("Dice data")]
    [Tooltip("Int final del dado el cual da el # de acciones del jugador.")]
    public int finalSide;

    [Tooltip("Int que determina el # de caras del dado, valor que debe ser " +
             "igual al # de caras del dado -1")]
    public int numberDiceFaces;

    public bool playerIsMoving;

    private void Awake()
    {
        rend = GetComponent<Image>();
        finalSide = 0;
        randomDiceSide = 0;
    }

    private void Start()
    {
    StartCoroutine(RollTheDice());
    }

    private IEnumerator RollTheDice()
    {
        
        do
        {
                randomDiceSide = Random.Range(0, numberDiceFaces);
                rend.sprite = diceSides[randomDiceSide + 1];
                yield return new WaitForSeconds(0.05f);
                Debug.Log(playerIsMoving);
        }

        while (playerIsMoving == false);

        playerIsMoving = false;
        finalSide = randomDiceSide + 1;
        rend.sprite = diceSides[finalSide];
    }

    public void NotifyPlayerMovent()
    {
        if (playerIsMoving == false)
        {
            playerIsMoving = true;
            Debug.Log("dice to true");
        }
    }

    public void NegativeCounter()
    {
        finalSide = finalSide - 1;
        finalSide = math.abs(finalSide);
        rend.sprite = diceSides[finalSide];
        if (finalSide == 0)
        {
            playerIsMoving = false;
            StartCoroutine(RollTheDice());

        }
    }
}
