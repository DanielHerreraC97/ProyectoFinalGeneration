using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class timer : MonoBehaviour
{
    //penalty
    public float _timer;
    public float resetTimer;
    public TMP_Text timerUI;
    private Dice _dice;
    
    void Start()
    {
        _dice = GameObject.FindWithTag("Dice").GetComponent<Dice>();

    }

    void Update()
    {
        _timer -= Time.deltaTime;
        timerUI.text = _timer.ToString();
        if (_dice.finalSide == 0)
        {
            _timer = resetTimer;
        }
    }
}
