
using UnityEngine;
using UnityEngine.SceneManagement;
public class introPrototipo : MonoBehaviour
{
    public string sceneName;
    private void Update()
    {
        desable();
    }

    private void desable()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
