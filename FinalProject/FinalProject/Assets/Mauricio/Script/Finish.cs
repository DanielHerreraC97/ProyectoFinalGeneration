using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public void RetryGame()
    {
        AudioManager.Instance.PlaySFX("Botones");
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        AudioManager.Instance.PlaySFX("Botones");
        SceneManager.LoadScene(0);
    }
}