using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Canvas Decision;

    private bool isInRange = false;

    private void Start()
    {
        Decision.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Decision.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Decision.gameObject.SetActive(false);
        }
    }

    public void OnYesButtonClicked()
    {
        if (isInRange)
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            Debug.Log("Esta en la escena" + SceneManager.GetActiveScene());
            if (currentScene == 1)
            {
                Debug.Log("cambia");
                SceneManager.LoadScene(2);
            }
            else if (currentScene == 2)
            {
                SceneManager.LoadScene(3);
            }
        }
    }

    public void OnNoButtonClicked()
    {
        if (isInRange)
        {
            Decision.gameObject.SetActive(false);
        }
    }
}
