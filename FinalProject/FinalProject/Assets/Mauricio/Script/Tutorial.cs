using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Canvas Tutorial1, Tutorial2;

    private bool isInRange = false;

    private void Start()
    {
        Tutorial1.gameObject.SetActive(false);
        Tutorial2.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial1"))
        {
            isInRange = true;
            Tutorial1.gameObject.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial2"))
        {
            isInRange = true;
            Tutorial2.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial1"))
        {
            isInRange = false;
            Tutorial1.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial2"))
        {
            isInRange = false;
            Tutorial2.gameObject.SetActive(false);
        }
    }
}
