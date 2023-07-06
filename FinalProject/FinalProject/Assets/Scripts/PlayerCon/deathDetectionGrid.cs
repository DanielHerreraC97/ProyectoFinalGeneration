using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class deathDetectionGrid : MonoBehaviour
{
    private GameObject player;
    private playerGridMovement _playerGridMovement;
    public Animator playerAnimator;
    private bool PlayerDeath;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        _playerGridMovement = player.GetComponent<playerGridMovement>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerLost();
        }
    }
    void PlayerLost()
    {
        _playerGridMovement.DisableControls();
        StartCoroutine(WaitForDeathAnimation());
        Finish.lastSceneName = SceneManager.GetActiveScene().name;
    }
    IEnumerator WaitForDeathAnimation()
    {
        playerAnimator.SetTrigger("IsDeath");
        AudioManager.Instance.PlaySFX("DeathP");
        float tiempoEsperaP = 2.0f;
        yield return new WaitForSecondsRealtime(tiempoEsperaP);
        SceneManager.LoadScene("GameOver");
    }
}