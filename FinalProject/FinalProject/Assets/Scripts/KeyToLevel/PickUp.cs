using UnityEngine;
public class PickUp : MonoBehaviour
{
   private gameManager _gameManager;
   private void Start()
   {
      _gameManager = FindObjectOfType<gameManager>().GetComponent<gameManager>();
   }
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         _gameManager.recollectedKey += 1;
         Destroy(gameObject);
      }
   }
}