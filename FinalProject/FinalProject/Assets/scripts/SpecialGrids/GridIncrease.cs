using UnityEngine;
public class GridIncrease : SpecialGrid
{
    [SerializeField] private int ActionPointsToIncrease;
    private new void ActivateEffect()
    {
        _dice.IncreaseCounter(ActionPointsToIncrease+1);
        Debug.Log("reduce " + ActionPointsToIncrease);
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