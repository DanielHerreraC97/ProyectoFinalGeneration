using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicePlacement : MonoBehaviour
{
    public GameObject enemyObject; // Referencia al objeto del enemigo
    public Image diceRenderer; // Referencia al componente SpriteRenderer del dado
    public float offsetY = 1f; // Desplazamiento vertical ajustable
    private float diceScale = .5f;

    private GameObject diceObject; // Referencia al objeto del dado
    private SpriteRenderer diceSpriteRenderer; // Referencia al componente SpriteRenderer del dado
    public EnemyDice diceScript; // Referencia al script EnemyDice

    private void Start()
    {
        // Desactiva el sprite en el canvas
        diceRenderer.enabled = false;

        // Coloca el objeto del dado sobre el objeto del enemigo al inicio
        PlaceDiceOnEnemy();
    }

    private void Update()
    {
        // Actualiza el sprite del dado con el resultado del lanzamiento
        diceSpriteRenderer.sprite = diceScript.diceSides[diceScript.finalSide];
    }

    private void PlaceDiceOnEnemy()
    {
        // Obtén la posición del enemigo
        Vector3 enemyPosition = enemyObject.transform.position;

        // Ajusta la posición del dado por encima del enemigo con el desplazamiento vertical
        Vector3 dicePosition = new Vector3(enemyPosition.x, enemyPosition.y + offsetY, enemyPosition.z);

        // Crea un objeto vacío para contener el sprite del dado en la escena
        diceObject = new GameObject("Dice");
        diceObject.transform.position = dicePosition;
        diceObject.transform.localScale = new Vector3(diceScale, diceScale, diceScale);

        // Crea un nuevo componente SpriteRenderer en el objeto vacío y asigna el sprite del dado
        diceSpriteRenderer = diceObject.AddComponent<SpriteRenderer>();
        diceSpriteRenderer.sprite = diceRenderer.sprite;

        // Establece el Order in Layer a 5
        diceSpriteRenderer.sortingOrder = 5;

        // Asigna el objeto del dado al objeto del enemigo como hijo
        diceObject.transform.SetParent(enemyObject.transform);
    }
}

