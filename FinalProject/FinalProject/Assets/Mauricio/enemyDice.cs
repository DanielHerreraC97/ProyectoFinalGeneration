using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
public class enemyDice : MonoBehaviour {

    [SerializeField]private Sprite[] diceSidesE;
    [SerializeField]private Image rend;
    public int finalSideE;

    private void Awake()
    {
        rend = GetComponent<Image>();
        diceSidesE = Resources.LoadAll<Sprite>("DiceSidesE/");
        finalSideE = 0;
    }

    private void Start () {
        StartCoroutine("RollTheDice");
    }
    
    private IEnumerator RollTheDice()
    {
        int randomDiceSideE = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSideE = Random.Range(0, 5);
            rend.sprite = diceSidesE[randomDiceSideE];
            yield return new WaitForSeconds(0.05f);
        }
        finalSideE = randomDiceSideE + 1;
    }
}