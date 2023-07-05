using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameManager : MonoBehaviour
{
    public PickUp _pickUp;
    public int recollectedKey;
    public TMP_Text keys;
    void Start()
    {
        recollectedKey = 0;
    }
    private void Update()
    {
        keys.text = "x" + recollectedKey.ToString();
    }
}