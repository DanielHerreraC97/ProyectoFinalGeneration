using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Canvas Decision;

    private bool isInRange = false;

    private GameObject player;
    private playerGridMovement _playerGridMovement;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        _playerGridMovement = player.GetComponent<playerGridMovement>();

        Decision.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Denreo");
            isInRange = true;
            Decision.gameObject.SetActive(true);
            _playerGridMovement.DisableControls();
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
            string currentScene = SceneManager.GetActiveScene().name;
            Debug.Log("Esta en la escena" + SceneManager.GetActiveScene());
            if (currentScene == "Tutorial")
            {
                Debug.Log("cambia");
                SceneManager.LoadScene("BaseLevel1");
            }
        }
    }

    public void OnNoButtonClicked()
    {
        if (isInRange)
        {
            Decision.gameObject.SetActive(false);
            _playerGridMovement.EnableControls();
        }
    }
}
