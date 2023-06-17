using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
public class Dice : MonoBehaviour {

    [SerializeField]private Sprite[] diceSides;
    [SerializeField]private Image rend;
    public int finalSide;

    private void Awake()
    {
        rend = GetComponent<Image>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        finalSide = 0;
    }

    private void Start () {
        StartCoroutine("RollTheDice");
    }
    
    private IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 5);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
        finalSide = randomDiceSide + 1;
    }
}