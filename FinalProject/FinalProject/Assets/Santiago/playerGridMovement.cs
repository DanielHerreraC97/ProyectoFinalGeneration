using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class playerGridMovement : MonoBehaviour
{
    [SerializeField] private Tilemap floor;
    [SerializeField] private Tilemap walls;
    private PlayerController controls;
    public float penaltyTime;
    
    //dice parameters 
    public int recall;
    private Dice _dice;
    
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
    public void Penalty(){
        
    }
}
