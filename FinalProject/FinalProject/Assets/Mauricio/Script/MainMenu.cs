using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    //UI
    public Slider MusicSlider, SFXSlider;

    //MainMenu
    public GameObject Mainmenu, Settingsmenu, Creditsmenu;

    private void Start()
    {
        Mainmenu.gameObject.SetActive(true);
        Settingsmenu.gameObject.SetActive(false);
        Creditsmenu.gameObject.SetActive(false);
    }

    public void PlayGame()
    {
        AudioManager.Instance.PlaySFX("Botones");
        SceneManager.LoadScene(4);
    }

    public void OpenSettings()
    {
        AudioManager.Instance.PlaySFX("Botones");
        Settingsmenu.gameObject.SetActive(true);
        Mainmenu.gameObject.SetActive(false);
    }

    public void OpenCredits()
    {
        AudioManager.Instance.PlaySFX("Botones");
        Creditsmenu.gameObject.SetActive(true);
        Mainmenu.gameObject.SetActive(false);
    }

    public void GoToMainMenu()
    {
        AudioManager.Instance.PlaySFX("Botones");
        Settingsmenu.gameObject.SetActive(false);
        Creditsmenu.gameObject.SetActive(false);
        Mainmenu.gameObject.SetActive(true);
    }

    public void ToogleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToogleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(MusicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(SFXSlider.value);
    }

    public void Mute()
    {
        AudioManager.Instance.PlaySFX("Botones");
        MusicSlider.value = 0;
    }
}
