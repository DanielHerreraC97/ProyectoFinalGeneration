using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
public class playerGridMovement : MonoBehaviour
{
    [SerializeField] private Tilemap floor;
    [SerializeField] private Tilemap walls;
    private PlayerController controls;
    public UnityEvent moveEnemies, restartEnemyDices;
    //dice parameters 
    public int recall,countToRestartenemiDices;
    private Dice _dice;
    //penalty
    public float timer;
    public float resetTimer;
    //public TMP_Text timerUI;

    public bool stopTimer, playerHasntMove;
    public Transform[] randomSpots;
    private Rigidbody2D rb;

    [SerializeField] private Slider slider;

    private void Awake()
    {
        controls = new PlayerController();
        rb= GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    void Start()
    {
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
       _dice = GameObject.FindWithTag("Dice").GetComponent<Dice>();
       stopTimer = false;
    }
    private void Update()
    {
        recall = _dice.finalSide;
        slider.maxValue = resetTimer;
        if (timer >= 0)
        {
            slider.value = timer;
        }   
    }
    private void Move(Vector2 direction)
    {
        if (PauseManager.paused) return;
        if (CanMove(direction) && recall > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction, 1f);
            //rb.MovePosition(transform.position += (Vector3)direction);
            _dice.NegativeCounter();
            restartEnemyDices?.Invoke();
            moveEnemies?.Invoke();
            timer = resetTimer;
            //slider.maxValue = resetTimer;
        }
    }
    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = floor.WorldToCell(transform.position + (Vector3)direction);
        if (!floor.HasTile(gridPosition) || walls.HasTile(gridPosition))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public IEnumerator TimerActor()
    {
        while (stopTimer)
        {
            timer -= Time.deltaTime;
            //timerUI.text = timer.ToString("F2");
            yield return new WaitForSeconds(0);
            if (timer < 0)
            {
                Punishment();
            }
        }
    }
    public void Punishment()
    {
        bool canPunish = false;

        Vector3 punishDirection;
        do
        {
        
            punishDirection = randomSpots[Random.Range(0, 4)].position;

            canPunish = CanItPunishmentInThatdirection(punishDirection);
        }
            while(canPunish == false );

        transform.position = Vector3.MoveTowards(transform.position, punishDirection, 1f);
       // transform.position = punishDirection;
        timer = resetTimer;
        restartEnemyDices?.Invoke();
        moveEnemies?.Invoke();
    }

    private bool CanItPunishmentInThatdirection(Vector3 directionToPunish)
    {
        Vector3Int gridPosition = floor.WorldToCell(directionToPunish);
        if (!floor.HasTile(gridPosition) || walls.HasTile(gridPosition))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}