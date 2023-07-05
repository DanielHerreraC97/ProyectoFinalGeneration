using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    public void RetryGame()
    {
        AudioManager.Instance.PlaySFX("Botones");
        SceneManager.LoadScene(2);
    }
    public void MainMenu()
    {
        AudioManager.Instance.PlaySFX("Botones");
        SceneManager.LoadScene(0);
    }
}