using UnityEngine;
using TMPro;
public class gameManager : MonoBehaviour
{
    public int recollectedKey;
    public TMP_Text keys;
    public static gameManager Instance;
    void Start()
    {
        PlayerPrefs.GetInt("keys");
        PlayerPrefs.GetInt("DisplayKeys");
        recollectedKey = 0 + PlayerPrefs.GetInt("keys");
    }
    private void Update()
    {
        PlayerPrefs.SetInt("keys", recollectedKey);
        PlayerPrefs.SetInt("DisplayKeys", recollectedKey);
        displayKeys();
    }
    void displayKeys()
    {
        keys.text = "x" + PlayerPrefs.GetInt("keys").ToString();
    }
}