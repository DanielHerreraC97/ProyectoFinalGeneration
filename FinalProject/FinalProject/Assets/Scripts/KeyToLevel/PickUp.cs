using UnityEngine;
public class PickUp : MonoBehaviour
{
   private gameManager _gameManager;
   public int wasTakenSet;
   GameObject thisKey;
   public string keyName;
   private void Start()
   {
      thisKey = new GameObject(keyName);
      PlayerPrefs.GetInt("wasTakenPrefs");
      _gameManager = FindObjectOfType<gameManager>().GetComponent<gameManager>();
      wasTakenSet = 0 + PlayerPrefs.GetInt(keyName);
   }
   private void Update()
   {
      takenControl();
   }
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         wasTakenSet += 1;
         PlayerPrefs.SetInt(keyName, wasTakenSet);
         _gameManager.recollectedKey += 1;
         Destroy(gameObject);
      }
   }
   void takenControl()
   {
      if (wasTakenSet == 1)
      {
         Destroy(gameObject);
      }
   }
}