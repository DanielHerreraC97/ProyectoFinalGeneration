using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    //UI
    public Slider MusicSlider, SFXSlider;

    //MainMenu
    public GameObject Pausemenu, Settingsmenu;

    private void Start()
    {
        Pausemenu.gameObject.SetActive(false);
        Settingsmenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Pause();
            Time.timeScale = 0;
        }
    }

    public void Pause()
    {
        Pausemenu.gameObject.SetActive(true);
    }

    public void Resume()
    {
        Pausemenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenSettings()
    {
        AudioManager.Instance.PlaySFX("Botones");
        Settingsmenu.gameObject.SetActive(true);
        Pausemenu.gameObject.SetActive(false);
    }

    public void Quit()
    {
        AudioManager.Instance.PlaySFX("Botones");
        SceneManager.LoadScene(0);
    }

    public void GoToPauseMenu()
    {
        AudioManager.Instance.PlaySFX("Botones");
        Settingsmenu.gameObject.SetActive(false);
        Pausemenu.gameObject.SetActive(true);
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

    public void MuteMusic()
    {
        AudioManager.Instance.PlaySFX("Botones");
    }

    public void MuteSFX()
    {
        AudioManager.Instance.PlaySFX("Botones");
    }
}
