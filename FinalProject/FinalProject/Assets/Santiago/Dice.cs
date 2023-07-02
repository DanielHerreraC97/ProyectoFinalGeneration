using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
public class Dice : MonoBehaviour {
    [Tooltip("Sprites de todas las caras del dado + sprite de desactivado. " +
             "El sprite desactivado debe ser #0. " +
             "De resto colocar en casilla correspondiente.")]
    public Sprite[] diceSides;
    private Image rend;
    private int randomDiceSide;
    private int lessSprite;
    private playerGridMovement _playerGridMovement;
    [Header("Dice data")]
    [Tooltip("Int final del dado el cual da el # de acciones del jugador.")]
    public int finalSide;
    [Tooltip("Float que determina el tiempo en que inicia la nueva tirada.")]
    public float timeToDelay;
    [Tooltip("Int que determina el # de caras del dado, valor que debe ser " +
             "igual al # de caras del dado -1")]
    public int numberDiceFaces;
    private void Awake()
    {
        _playerGridMovement = GameObject.FindWithTag("Player").GetComponent<playerGridMovement>();
        rend = GetComponent<Image>();
        finalSide = 0;
        randomDiceSide = 0;
        lessSprite = 0;
    }
    private void Start () {
        StartCoroutine(RollTheDice());
        //StartCoroutine(WaitTutorial());
    }
    
    /*private IEnumerator WaitTutorial()
    {
        Time.timeScale = 0;
        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 1;
    }*/

    private IEnumerator RollTheDice()
    {
        //  yield return new WaitForSeconds(timeToDelay);
    
        for (int i = 0; i <= 10; i++)
        {
            randomDiceSide = Random.Range(0, numberDiceFaces);
            rend.sprite = diceSides[randomDiceSide+1];
            yield return new WaitForSeconds(0.05f);
        }

        finalSide = randomDiceSide + 1;
        _playerGridMovement.stopTimer = true;
        if (!_playerGridMovement.isTimerWorking )
        {
            StartCoroutine(_playerGridMovement.TimerActor());
        }
    }
    public void NegativeCounter(int pointsToReduce = 1)
    {
        finalSide -= pointsToReduce;
        if(finalSide <= 0 ) finalSide= 0;
        lessSprite = finalSide;
        rend.sprite = diceSides[lessSprite];
        if (finalSide <= 0)
        {
            _playerGridMovement.stopTimer = false;
            Debug.Log("1");
            StartCoroutine(RollTheDice());
        }
    }

    public void IncreaseCounter(int pointsToIncrease)
    {
        finalSide += pointsToIncrease;
        if (finalSide >= 20) finalSide = 20;
        lessSprite = finalSide;
        rend.sprite = diceSides[lessSprite];
    }
}