using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CreateDice : MonoBehaviour
{
  private DiceCollection _diceCollection;
  private Inventory _inventory;
  public GameObject diceButton;
  public int numberDiceFaces;
  public TMP_Text numberDicesFacesTM;
  private int diceCreated;
  public GameObject equipDice;
  public bool craftedDice;
  private void Start()
  {
    _diceCollection = GameObject.FindGameObjectWithTag("DiceCollection").GetComponent<DiceCollection>();
    _inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    craftedDice = false;
  }
  private void Update()
  {
    numberDicesFacesTM.text = numberDiceFaces.ToString();
    ChangeButton();
  }
  private void ChangeButton()
  {
    if (diceCreated == 1)
    {
      gameObject.SetActive(false);
      equipDice.SetActive(true);
    }
  }
  private void NewDice()
  {
    if (_inventory.numberItem >= numberDiceFaces)
    {
      for (int i = 0; i < _diceCollection.slots.Length; i++)
      {
        if (_diceCollection.isFull[i]==false)
        {
          craftedDice = true;
          _diceCollection.isFull[i] = true;
          Instantiate(diceButton, _diceCollection.slots[i].transform, false);
          diceCreated += 1;
          break;
        }
      }
    }
  }
}