using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLosePoints : SpecialGrid
{
    [SerializeField] private int ActionPointsToReduce;
  private new void ActivateEffect()
    {
        _dice.NegativeCounter(ActionPointsToReduce-1);
        Debug.Log("reduce " + ActionPointsToReduce);
        
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
