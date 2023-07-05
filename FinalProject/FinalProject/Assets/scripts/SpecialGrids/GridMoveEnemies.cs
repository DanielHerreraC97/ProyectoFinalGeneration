using UnityEngine;
public class GridMoveEnemies : SpecialGrid
{
    [SerializeField] private int enemiesSteps;
    private new void ActivateEffect()
    {
       for(int i=0; i<enemiesSteps-1;i++)
       {
            _playerGridMovement.restartEnemyDices?.Invoke();
            _playerGridMovement.moveEnemies?.Invoke(); 
       }
    }
    protected new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ActivateEffect();
            Destroy(gameObject);
        }
    }
}