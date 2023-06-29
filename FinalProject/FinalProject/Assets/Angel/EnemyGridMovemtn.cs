using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class EnemyGridMovemtn : MonoBehaviour
{

    [SerializeField] private Tilemap floor;
    [SerializeField] private Tilemap walls;

    public enum EnemyType{horizontal, vertical, DiagonalLefttoRigth, DiagonalRighttoLeft}
    public EnemyType enemyType;

    [SerializeField] private string namePostionA, namePositionB;
    [SerializeField] private bool moveToA;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rigidbody2DEnemie;
    private Vector2 movement;


    //dice parameters 
    public int recall;
    [SerializeField] private EnemyDice _dice;

 private Rigidbody2D rb;

    private playerGridMovement player;

    private void Awake()
    {
        spriteRenderer= this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        boxCollider2D= GetComponent<BoxCollider2D>();
        rigidbody2DEnemie= GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<playerGridMovement>();
        player.moveEnemies.AddListener(MoveThisEnemy);
        DefineINicialMovementObjective();
    }

    private void Update()
    {
        recall = _dice.finalSide;
    }

    public void MoveThisEnemy()
    {
        switch(enemyType)
        { case EnemyType.horizontal:
                HorizontalMovement();
                break; 
          case EnemyType.vertical:
                VerticalMovement();
                break;
          case EnemyType.DiagonalLefttoRigth:
                DiagonalLeftToRigthMovement();
                break;
          case EnemyType.DiagonalRighttoLeft:
                DiagonalRigthToLeftMovement();
                break;
        }


        _dice.NegativeCounter();
    }

    private void DefineINicialMovementObjective()
    {
      int randomMovementDirection = Random.Range(0, 2);

        if (randomMovementDirection >= 1)
        {
            moveToA = true;
        }
        else 
        {
        moveToA= false;
        }
     
    }


     private void HorizontalMovement()
    { 

        if(moveToA)
        {
            movement = new Vector2(1, 0);
        }

        else
        {
            movement = new Vector2(-1, 0);
        }

        Move(movement);
    }

    private void VerticalMovement() 
    {
        if (moveToA)
        {
            movement = new Vector2(0, 1);
        }

        else
        {
            movement = new Vector2(0,-1);
        }

        Move(movement);
    }

    private void DiagonalLeftToRigthMovement()
    {
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;
        rigidbody2DEnemie.Sleep();

        if (moveToA)
        {
            movement = new Vector2(0, 1);
            Move(movement);
            movement = new Vector2(1, 0);
            Move(movement);
        }

        else
        {
            movement = new Vector2(0, -1);
            Move(movement);
            movement = new Vector2(-1, 0);
            Move(movement);
        }
        rigidbody2DEnemie.WakeUp();
        boxCollider2D.enabled = true;
        spriteRenderer.enabled = true;
    }

    private void DiagonalRigthToLeftMovement()
    {
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;
        rigidbody2DEnemie.Sleep();

        if (moveToA)
        {
            movement = new Vector2(0, 1);
            Move(movement);
            movement = new Vector2(-1, 0);
            Move(movement);
        }

        else
        {
            movement = new Vector2(0, -1);
            Move(movement);
            movement = new Vector2(1, 0);
            Move(movement);
        }
        rigidbody2DEnemie.WakeUp();
        boxCollider2D.enabled = true;
        spriteRenderer.enabled = true;
    }

        private void Move(Vector2 direction)
    {
        if (CanMove(direction) && recall > 0)
        {
            //transform.position = Vector3.MoveTowards(transform.position, direction, 1f);
            rb.MovePosition(transform.position += (Vector3)direction);
            if (_dice.finalSide == 0)
            {
                _dice.StartCoroutine("RollTheDice");
            }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == namePostionA)
        {
            moveToA = false;
        }

        if (collision.gameObject.name == namePositionB)
        {
            moveToA = true;
        }

     /*   if (collision.CompareTag("Player"))
        {
            Debug.Log("Batalla");
            diceBattle.Battle();
        }
     
     */
    }
}
