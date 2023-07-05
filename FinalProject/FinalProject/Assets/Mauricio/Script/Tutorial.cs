using UnityEngine;
public class Tutorial : MonoBehaviour
{
    public Canvas Tutorial1, Tutorial2, Tutorial3, Tutorial4, Tutorial5, Tutorial6, Tutorial7;
    private void Start()
    {
        Tutorial1.gameObject.SetActive(false);
        Tutorial2.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial1"))
        {
            Tutorial1.gameObject.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial2"))
        {
            Tutorial2.gameObject.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial3"))
        {
            Tutorial3.gameObject.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial4"))
        {
            Tutorial4.gameObject.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial5"))
        {
            Tutorial5.gameObject.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial6"))
        {
            Tutorial6.gameObject.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial7"))
        {
            Tutorial7.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial1"))
        {
            Tutorial1.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial2"))
        {
            Tutorial2.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial3"))
        {
            Tutorial3.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial4"))
        {
            Tutorial4.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial5"))
        {
            Tutorial5.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial6"))
        {
            Tutorial6.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Tutorial7"))
        {
            Tutorial7.gameObject.SetActive(false);
        }
    }
}