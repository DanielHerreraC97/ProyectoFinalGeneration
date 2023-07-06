using UnityEngine;
public class Stairs : MonoBehaviour
{
    public static Stairs activeStairs;
    public string nivelAScena;
    private gameManager _gameManager;
    public int requiredKeys;
    public int haveKeys;
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<gameManager>().GetComponent<gameManager>();
    }
    void Update()
    {
        haveKeys = PlayerPrefs.GetInt("keys");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activeStairs = this;
        }
    }
}