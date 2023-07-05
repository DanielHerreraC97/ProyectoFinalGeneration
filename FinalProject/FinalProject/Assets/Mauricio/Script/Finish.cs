using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    public static string lastSceneName;

    private void Start()
    {
    }

    public void RetryGame()
    {
        AudioManager.Instance.PlaySFX("Botones");
        SceneManager.LoadScene(lastSceneName);
    }

    public void Base()
    {
        AudioManager.Instance.PlaySFX("Botones");
        SceneManager.LoadScene("BaseLevel");
    }
    public void MainMenu()
    {
        AudioManager.Instance.PlaySFX("Botones");
        SceneManager.LoadScene("MainMenu");
    }
}