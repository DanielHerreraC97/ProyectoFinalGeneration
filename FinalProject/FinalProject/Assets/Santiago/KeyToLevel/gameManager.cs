using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class gameManager : MonoBehaviour
{
    private PickUp _pickUp;
    public int recollectedKey;
    public TMP_Text keys;
    void Start()
    {
        recollectedKey = 0;
    }
    private void Update()
    {
        keys.text = recollectedKey.ToString();
    }
}