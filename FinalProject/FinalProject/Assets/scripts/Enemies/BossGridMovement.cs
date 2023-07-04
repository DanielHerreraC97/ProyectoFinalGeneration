using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BossGridMovement : MonoBehaviour
{
    [SerializeField] private GameObject spaceOne, spaceTwo, spaceThree, spaceFour;
    private int positionCount, actualPosition, lifesCount;

    private GameObject player;
    private playerGridMovement _playerGridMovement;
    [SerializeField] private EnemyDice _dice;
    public int enemyEnergy;

    public Animator enemyAnimator;
    public Animator playerAnimator;

    public TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        _playerGridMovement = player.GetComponent<playerGridMovement>();
        _playerGridMovement.moveEnemies.AddListener(MoveThisEnemy);
    }
    private void Start()
    {
        positionCount = 0;
        transform.position = spaceOne.transform.position;
        actualPosition = 1;
        lifesCount = 3;
        textMeshPro.text = lifesCount.ToString();
    }

    private void Update()
    {
        enemyEnergy = _dice.finalSide;
    }

    public void MoveThisEnemy()
    {
        if (positionCount >= 3)
        {
            Move();
        }
        else
        {
            positionCount++;
        }

        _dice.NegativeCounter();
    }

    private void Move()
    {
        if (actualPosition == 1)
        {
            transform.position = spaceTwo.transform.position;
            actualPosition = 2;
            positionCount = 0;
        }

        else if (actualPosition == 2 && lifesCount == 3)
        {
            transform.position = spaceOne.transform.position;
            actualPosition = 1;
            positionCount = 0;
        }

        else if (actualPosition == 2 && lifesCount < 3)
        {
            transform.position = spaceThree.transform.position;
            actualPosition = 3;
            positionCount = 0;

        }

        else if (actualPosition == 3 && lifesCount == 2)
        {
            transform.position = spaceOne.transform.position;
            actualPosition = 1;
            positionCount = 0;

        }

        else if (actualPosition == 3 && lifesCount < 2)
        {
            transform.position = spaceFour.transform.position;
            actualPosition = 4;
            positionCount = 0;
        }

        else
        {
            transform.position = spaceOne.transform.position;
            actualPosition = 1;
            positionCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_playerGridMovement.recall > enemyEnergy)
            {
                lifesCount = lifesCount - 1;
                textMeshPro.text = lifesCount.ToString();
                Move();

                if (lifesCount<=0) 
                {
                    BossLose();
                }
            }

            if (_playerGridMovement.recall <= enemyEnergy)
            {
                PlayerLost();
            }
        }
    }

    public void BossLose()
    {
        StartCoroutine(WaitForDeathAnimationEnemie());
    }

    private IEnumerator WaitForDeathAnimationEnemie()
    {
        enemyAnimator.SetTrigger("IsDeath");
        AudioManager.Instance.PlaySFX("DeathM");
        float tiempoEsperaE = 2f;
        yield return new WaitForSecondsRealtime(tiempoEsperaE);
        gameObject.SetActive(false);
    }

    public void PlayerLost()
    {
        _playerGridMovement.DisableControls();
        _playerGridMovement.restartEnemyDices?.Invoke();
        _playerGridMovement.moveEnemies?.Invoke();
        StartCoroutine(WaitForDeathAnimation());
    }

    private IEnumerator WaitForDeathAnimation()
    {
            playerAnimator.SetTrigger("IsDeath");
            AudioManager.Instance.PlaySFX("DeathP");
            float tiempoEsperaP = 2.0f;
            yield return new WaitForSecondsRealtime(tiempoEsperaP);
            SceneManager.LoadScene(4);

    }
}

