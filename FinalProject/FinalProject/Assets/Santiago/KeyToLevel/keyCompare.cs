using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keyCompare : MonoBehaviour
{
    private sendToLevel _sendToLevel;
    public string sceneName;

    void Start()
    {
        _sendToLevel = GetComponentInParent<sendToLevel>();
    }

    void Update()
    {
        changeScene();
    }
    private void changeScene()
    {
        
        if (Input.GetKeyDown(KeyCode.L) && _sendToLevel.haveKeys >= _sendToLevel.requiredKeys)
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (Input.GetKeyDown(KeyCode.L) && _sendToLevel.haveKeys < _sendToLevel.requiredKeys)
        {
            Debug.Log("pene");
        }
    }
}
