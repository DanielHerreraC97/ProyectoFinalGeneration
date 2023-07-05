using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sing : MonoBehaviour
{
    public Canvas DiagCanvas;
    public GameObject Tutorial;
    public Image Image1;
    public Image Image2;

    private bool isInRange = false;
    private bool isTutorialOpen = false;

    private bool isFirstImageShown = false;
    public float timeBetweenImages = 1f;

    private GameObject player;
    private playerGridMovement _playerGridMovement;

    public RectTransform Signal;
    private float originalY;
    public float moveRange = 3f;
    public float moveDuration = 1f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        _playerGridMovement = player.GetComponent<playerGridMovement>();

        DiagCanvas.gameObject.SetActive(false);
        Image1.gameObject.SetActive(false);
        Image2.gameObject.SetActive(false);
        Tutorial.gameObject.SetActive(false);

        originalY = Signal.localPosition.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Dentro");
            isInRange = true;
            DiagCanvas.gameObject.SetActive(true);
            isFirstImageShown = true;
            StartCoroutine(ShowImagesCoroutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            DiagCanvas.gameObject.SetActive(false);
            Image1.gameObject.SetActive(false);
            Image2.gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            isTutorialOpen = !isTutorialOpen;

            if (isTutorialOpen)
            {
                Tutorial.SetActive(true);
                Time.timeScale = 0;
                _playerGridMovement.DisableControls();
            }
            else
            {
                Tutorial.SetActive(false);
                Time.timeScale = 1;
                _playerGridMovement.EnableControls();
            }
        }


        float upperLimit = originalY + moveRange; // Límite superior del rango de movimiento
        float lowerLimit = originalY - moveRange; // Límite inferior del rango de movimiento

        float newY = Mathf.PingPong(Time.time * (1f / moveDuration), moveRange * 2) - moveRange + originalY;

        Signal.localPosition = new Vector3(Signal.localPosition.x, newY, Signal.localPosition.z);
    }

    private IEnumerator ShowImagesCoroutine()
    {
        while (isInRange)
        {
            if (isFirstImageShown)
            {
                Image1.gameObject.SetActive(true);
                Image2.gameObject.SetActive(false);
            }
            else
            {
                Image1.gameObject.SetActive(false);
                Image2.gameObject.SetActive(true);
            }

            isFirstImageShown = !isFirstImageShown;

            yield return new WaitForSeconds(timeBetweenImages);
        }
    }
}

