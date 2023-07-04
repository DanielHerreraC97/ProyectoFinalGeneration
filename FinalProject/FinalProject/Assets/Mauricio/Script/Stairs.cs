using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour
{
    public static Stairs activeStairs;
    public string nivelAScena; // Nombre de la escena a cargar para este pasillo

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activeStairs = this; // Actualiza la referencia al objeto activo
            // Resto del código...
        }
    }
}
