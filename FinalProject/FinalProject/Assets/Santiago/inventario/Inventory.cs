using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
  public bool[] isFull;
  public GameObject[] slots;
  public TMP_Text score;
  public int numberItem;
  private void Start()
  {
    numberItem = 0;
  }

  public void plusItem()
  {
    numberItem += 1;
    score.text = numberItem.ToString();
  }
} 
