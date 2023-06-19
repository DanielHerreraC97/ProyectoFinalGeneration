using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
   private Inventory _inventory;
   public GameObject itemButton;

   private void Start()
   {
      _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
      
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         for (int i = 0; i < _inventory.slots.Length; i++)
         {
            if (_inventory.isFull[i]==false)
            {
               _inventory.isFull[i] = true;
               _inventory.plusItem();
               Instantiate(itemButton, _inventory.slots[i].transform, false); 
               Destroy(gameObject);
               break;
            }
         }
      }
   }
}
