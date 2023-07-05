using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    //UI
    public Slider MusicSlider, SFXSlider;
    //MainMenu
    public GameObject Mainmenu, Settingsmenu, Creditsmenu, Assetsmenu;
    public static bool TutorialComplete { get; set; } = false;
    private void Start()
    {
        Mainmenu.gameObject.SetActive(true);
        Settingsmenu.gameObject.SetActive(false);
        Creditsmenu.gameObject.SetActive(false);
        Assetsmenu.gameObject.SetActive(false);
        TutorialComplete = false;
    }
    public void PlayGame()
    {
        AudioManager.Instance.PlaySFX("Botones");
        if (!MainMenu.TutorialComplete)
        {
            SceneManager.LoadScene("Tutorial");
            MainMenu.TutorialComplete = true;
        }
        else
        {
            SceneManager.LoadScene("BaseLevel");
        }
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
        Assetsmenu.gameObject.SetActive(false);
    }
    public void OpenAssets()
    {
        AudioManager.Instance.PlaySFX("Botones");
        Creditsmenu.gameObject.SetActive(false);
        Assetsmenu.gameObject.SetActive(true);
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
        //MusicSlider.value = 0;
    }
}