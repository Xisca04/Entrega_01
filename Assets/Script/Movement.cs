using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Player's movement

    private Vector2Int gridPosition;
    private Vector2Int startGridPosition;
    private Vector2Int gridMoveDirection;

    private float gridTimer;
    private float gridTimerMax = 1f; 

    private void Awake()
    {
        startGridPosition = new Vector2Int(0, 0);
        gridPosition = startGridPosition;
        gridMoveDirection = new Vector2Int(1, 1); // Right-up por defecto
    }

    private void Update()
    {
        GridMovement();
        HandleMovement();
    }

    private void HandleMovement()
    {
        //Right-up movement
        if (Input.GetKeyDown(KeyCode.E) && !Input.GetKeyDown(KeyCode.A)) // Movement left-down blocked
        {
            gridMoveDirection.x = 1;
            gridMoveDirection.y = 1;
        }

        //Right-down movement
        if (Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.Q)) // Movement left-up blocked
        {
            gridMoveDirection.x = 1;
            gridMoveDirection.y = -1;
        }

        //Left-up movement
        if (Input.GetKeyDown(KeyCode.Q) && !Input.GetKeyDown(KeyCode.D)) // Movement right-down blocked
        {
            gridMoveDirection.x = -1;
            gridMoveDirection.y = 1;
        }
        
        //Left-down movement
        if (Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.E)) // Movement right-up blocked
        {
            gridMoveDirection.x = -1;
            gridMoveDirection.y = -1;
        }
    }

    private void GridMovement()
    {
        gridTimer += Time.deltaTime;

        if (gridTimer >= gridTimerMax)
        {
            gridTimer -= gridTimerMax;
            gridPosition += gridMoveDirection;
            transform.position = new Vector3(gridPosition.x, gridPosition.y, 0);
        }
}   }



