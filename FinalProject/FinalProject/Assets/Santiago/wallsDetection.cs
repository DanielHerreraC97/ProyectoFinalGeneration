using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class wallsDetection : MonoBehaviour
{
    public bool wallClose;
    public bool wallFar;
    private void Update()
    {
        wallClose = false;
        wallFar = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Walls")
        {
            Debug.Log("col");
            wallClose = true;
            wallFar = false;
        }
    }
}
