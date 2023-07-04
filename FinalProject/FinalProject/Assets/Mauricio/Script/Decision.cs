using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Decision : MonoBehaviour
{
    public Canvas _decision;

    private bool isInRange = false;

    private GameObject player;
    private playerGridMovement _playerGridMovement;

    public Stairs stairs;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        _playerGridMovement = player.GetComponent<playerGridMovement>();

        _decision.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Denreo");
            isInRange = true;
            _decision.gameObject.SetActive(true);
            Time.timeScale = 0;
            _playerGridMovement.DisableControls();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            _decision.gameObject.SetActive(false);
        }
    }

    /*public void OnYesButtonClicked()
    {
        /*if (isInRange)
        {
            Stairs pass = FindObjectOfType<Stairs>();
            if (pass != null)
            {
                string nivelAScena = pass.nivelAScena;
                SceneManager.LoadScene(nivelAScena);
            }
            else
            {
                Debug.LogWarning("No se encontró ningún objeto con el script PasilloCollisionHandler");
            }
        }*/

    /*if (isInRange && stairs != null)
    {
        string nivelAScena = stairs.nivelAScena;
        SceneManager.LoadScene(nivelAScena);
    }
}*/

    public void OnYesButtonClicked()
    {
        if (isInRange && Stairs.activeStairs != null)
        {
            string nivelAScena = Stairs.activeStairs.nivelAScena;
            SceneManager.LoadScene(nivelAScena);
        }
    }

    public void OnNoButtonClicked()
    {
        if (isInRange)
        {
            _decision.gameObject.SetActive(false);
            _playerGridMovement.EnableControls();
            Time.timeScale = 1;
        }
    }
}
