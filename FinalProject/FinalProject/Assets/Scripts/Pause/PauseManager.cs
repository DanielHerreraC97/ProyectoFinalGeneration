using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseManager : MonoBehaviour
{
   public static bool paused = false;
   private PauseAction action;
   public GameObject _menu;
   private void Awake()
   {
      action = new PauseAction();
   }
   private void OnEnable()
   {
      action.Enable();
   }
   private void OnDisable()
   {
      action.Disable();
   }
   private void Start()
   {
      action.Pause.PauseGame.performed += _ => DeterminePause();
   }
   private void DeterminePause()
   {
      if (paused)
      {
         ResumeGame();
      }
      else
      {
         PauseGame();
      }
   }
   public void PauseGame()
   {
      Time.timeScale = 0;
      paused = true;
      _menu.SetActive(true);
   }
   public void ResumeGame()
   {
      Time.timeScale = 1;
      paused = false;
      _menu.SetActive(false);
   }
}