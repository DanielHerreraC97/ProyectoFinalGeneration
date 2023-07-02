using UnityEngine;
public class sendToLevel : MonoBehaviour
{
    private gameManager _gameManager;
    public int requiredKeys;
    public GameObject letter;
    public int haveKeys;
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<gameManager>().GetComponent<gameManager>();
        letter.SetActive(false);
    }
    void Update()
    {
        haveKeys = _gameManager.recollectedKey;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            letter.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        letter.SetActive(false);
    }
}