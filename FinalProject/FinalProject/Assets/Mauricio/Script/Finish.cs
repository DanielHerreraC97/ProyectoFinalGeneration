using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    public static string lastSceneName;
    public static bool TutorialComplete;
    public GameObject Complete, NoComplete;

    //private string ActualScene = SceneManager.GetActiveScene().name;

    private void Update()
    {
        if (lastSceneName == "Tutorial")
        {
            Debug.Log(lastSceneName + " es la escena");
            TutorialComplete = false;
        }
        else
        {
            TutorialComplete = true;
        }

        if (TutorialComplete == false)
        {
            NoComplete.gameObject.SetActive(true);
            Complete.gameObject.SetActive(false);
        }
        if (TutorialComplete == true)
        {
            Complete.gameObject.SetActive(true);
            NoComplete.gameObject.SetActive(false);
        }
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
        PlayerPrefs.DeleteAll();
        AudioManager.Instance.PlaySFX("Botones");
        SceneManager.LoadScene("MainMenu");
    }
}