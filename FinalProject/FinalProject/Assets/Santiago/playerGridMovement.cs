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
    public UnityEvent moveEnemies;
    //dice parameters 
    public int recall;
    private Dice _dice;
    //penalty
    public float timer;
    public float resetTimer;
    public TMP_Text timerUI;
    public bool stopTimer;
    public Transform[] randomSpots;
    private void Awake()
    {
        controls = new PlayerController();
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
    }
    private void Move(Vector2 direction)
    {
        if (PauseManager.paused) return;
        if (CanMove(direction) && recall > 0)
        {
            transform.position += (Vector3)direction;
            _dice.NegativeCounter();
            moveEnemies?.Invoke();
            timer = resetTimer;
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
            timerUI.text = timer.ToString();
            yield return new WaitForSeconds(0);
            if (timer < 0)
            {
                Punishment();
            }
        }
    }
    public void Punishment()
    {
        transform.position = randomSpots[Random.Range(0, 3)].position;
            timer = resetTimer;
            Debug.Log("punishment!");
    }
}