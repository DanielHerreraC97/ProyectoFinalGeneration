using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/*public class enemyGridMovement : MonoBehaviour
{
    [SerializeField] private Tilemap floor;
    [SerializeField] private Tilemap walls;
    private EnemyController controls;

    //dice parameters 
    public int recall;
    private Dice _dice;

    private void Awake()
    {
        controls = new EnemyController();
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
        _dice = GameObject.Find("enemyDice").GetComponent<Dice>();
    }

    private void Update()
    {
        recall = _dice.finalSide;
    }

    private void Move(Vector2 direction)
    {
        if (CanMove(direction) && recall > 0)
        {
            transform.position += (Vector3)direction;
            _dice.finalSide -= 1;
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
}*/

/*public class enemyGridMovement : MonoBehaviour
{
    [SerializeField] private Tilemap floor;
    [SerializeField] private Tilemap walls;
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;

    // Dados y movimiento
    public int recall;
    private enemyDice _dice;

    private bool canMove = false;

    private void Start()
    {
        // Obtener referencias a los waypoints en el escenario
        waypoints = new Transform[2];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = GameObject.Find("Waypoint" + (i + 1)).transform; // Reemplaza "Waypoint" con el nombre de tus waypoints en el escenario
        }

        _dice = GameObject.Find("diceE").GetComponent<enemyDice>(); // Asegúrate de que el dado del enemigo tenga el nombre correcto

        StartEnemyMovement();
    }

    private void Update()
    {
        if (!canMove)
            return;

        recall = _dice.finalSideE;

        if (recall <= 0)
        {
            // El enemigo ha terminado su movimiento basado en el dado
            if (_dice != null && _dice.gameObject.activeInHierarchy)
            {
                _dice.StartCoroutine("RollTheDice");
                canMove = false;
            }
        }
        else
        {
            // Movimiento en la cuadrícula basado en el dado
            if (CanMove() && recall > 0)
            {
                Vector3Int currentCellPosition = floor.WorldToCell(transform.position);
                Vector3Int targetCellPosition = GetNextCellPosition(currentCellPosition);

                if (targetCellPosition != currentCellPosition)
                {
                    Vector3 targetWorldPosition = floor.GetCellCenterWorld(targetCellPosition);
                    Vector3 moveDirection = targetWorldPosition - transform.position;

                    moveDirection.Normalize();
                    transform.position += moveDirection * Time.deltaTime;

                    // Verificar si llegó a la siguiente celda
                    if (Vector3.Distance(transform.position, targetWorldPosition) <= 0.01f)
                    {
                        recall--;
                    }
                }
            }
        }
    }

    private bool CanMove()
    {
        Vector3Int currentCellPosition = floor.WorldToCell(transform.position);
        Vector3Int targetCellPosition = GetNextCellPosition(currentCellPosition);

        // Verificar si la siguiente celda está disponible para moverse
        if (!floor.HasTile(targetCellPosition) || walls.HasTile(targetCellPosition))
        {
            return false;
        }

        return true;
    }

    private Vector3Int GetNextCellPosition(Vector3Int currentCellPosition)
    {
        // Lógica para determinar la siguiente celda basada en el dado
        // Aquí puedes implementar tu propia lógica para determinar cómo el enemigo selecciona la siguiente celda en función del dado
        // Por ejemplo, podrías usar un número aleatorio o alguna estrategia específica

        // Ejemplo de lógica: alternar entre los dos waypoints
        if (currentWaypointIndex == 0)
        {
            currentWaypointIndex = 1;
        }
        else
        {
            currentWaypointIndex = 0;
        }

        return floor.WorldToCell(waypoints[currentWaypointIndex].position);
    }

    public void StartEnemyMovement()
    {
        recall = _dice.finalSideE;
        canMove = true;
    }
}*/

public class enemyGridMovement : MonoBehaviour
{
    [SerializeField] private Tilemap floor;
    [SerializeField] private Tilemap walls;
    private Transform[] waypoints;

    // Dados y movimiento
    public int recallE;
    private enemyDice _diceE;

    private bool canMove = false;

    private void Start()
    {
        // Obtener referencias a los waypoints en el escenario
        waypoints = new Transform[2];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = GameObject.Find("Waypoint" + (i + 1)).transform;
        }

        _diceE = GameObject.Find("diceE").GetComponent<enemyDice>();

        StartEnemyMovement();
    }

    private void Update()
    {
        if (!canMove)
            return;

        recallE = _diceE.finalSideE;

        if (recallE <= 0)
        {
            // El enemigo ha terminado su movimiento basado en el dado
            if (_diceE != null && _diceE.gameObject.activeInHierarchy)
            {
                _diceE.StartCoroutine("RollTheDice");
                canMove = false;
            }
        }
        else
        {
            // Movimiento aleatorio en la cuadrícula basado en el dado
            if (CanMove() && recallE > 0)
            {
                Vector3Int currentCellPosition = floor.WorldToCell(transform.position);

                // Generar una dirección de movimiento aleatoria
                Vector2 randomDirection = RandomDirection();

                // Calcular la siguiente posición basada en la dirección aleatoria
                Vector3Int targetCellPosition = currentCellPosition + new Vector3Int((int)randomDirection.x, (int)randomDirection.y, 0);

                if (targetCellPosition != currentCellPosition)
                {
                    Vector3 targetWorldPosition = floor.GetCellCenterWorld(targetCellPosition);
                    Vector3 moveDirection = targetWorldPosition - transform.position;

                    moveDirection.Normalize();
                    transform.position += moveDirection * Time.deltaTime;

                    // Verificar si llegó a la siguiente celda
                    if (Vector3.Distance(transform.position, targetWorldPosition) <= 0.01f)
                    {
                        recallE--;
                    }
                }
            }
        }
    }

    private bool CanMove()
    {
        Vector3Int currentCellPosition = floor.WorldToCell(transform.position);

        // Verificar si la siguiente celda está disponible para moverse
        Vector3Int targetCellPosition = currentCellPosition + new Vector3Int((int)RandomDirection().x, (int)RandomDirection().y, 0);
        if (!floor.HasTile(targetCellPosition) || walls.HasTile(targetCellPosition))
        {
            return false;
        }

        return true;
    }

    private Vector2 RandomDirection()
    {
        // Generar una dirección de movimiento aleatoria
        int randomValue = Random.Range(1, 5); // Generar un número aleatorio del 1 al 4
        Vector2 direction = Vector2.zero;

        // Asignar la dirección correspondiente al valor aleatorio
        switch (randomValue)
        {
            case 1:
                direction = Vector2.up;
                break;
            case 2:
                direction = Vector2.down;
                break;
            case 3:
                direction = Vector2.left;
                break;
            case 4:
                direction = Vector2.right;
                break;
        }

        return direction;
    }

    public void StartEnemyMovement()
    {
        Debug.Log("No entra");
        recallE = _diceE.finalSideE;
        canMove = true;
    }

}

