using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Entregable 1
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

    }

    // Solución Entregable 1
    /*
    private float timer;
    private float timerMax = 1f;

    private float diagonalUpInput; // Keys Q and E
    private float diagonalDownInput; // Keys A and D

    private Vector2Int position2D;
    private Vector2Int moveDirection;

    private void Awake()
    {
        // Initial position
        position2D = Vector2Int.zero;
        transform.position = new Vector3(position2D.x, position2D.y, 0);

        // The first move is right-up
        moveDirection = new Vector2Int(1, 1);
    }

    private void Update()
    {
        Movement();
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            timer -= timerMax;

            position2D += moveDirection;
            transform.position = new Vector3(position2D.x, position2D.y, 0);
        }
    }

    private void Movement()
    {
        // DiagonalUp and DiagonalDown Axes where created in Input Manager
        diagonalUpInput = Input.GetAxisRaw("Diagonal Up");
        diagonalDownInput = Input.GetAxisRaw("Diagonal Down");

        Vector2Int previousDirection = moveDirection;
        bool validNewPosition = true;

        if (diagonalUpInput > 0)
        {
            moveDirection = new Vector2Int(1, 1);
            validNewPosition = IsNewDirectionValid(previousDirection, moveDirection);

        }
        if (diagonalUpInput < 0)
        {
            moveDirection = new Vector2Int(-1, 1);
            validNewPosition = IsNewDirectionValid(previousDirection, moveDirection);
        }
        if (diagonalDownInput > 0)
        {
            moveDirection = new Vector2Int(1, -1);
            validNewPosition = IsNewDirectionValid(previousDirection, moveDirection);
        }
        if (diagonalDownInput < 0)
        {
            moveDirection = new Vector2Int(-1, -1);
            validNewPosition = IsNewDirectionValid(previousDirection, moveDirection);
        }

        if (!validNewPosition) moveDirection = previousDirection;
    }

    private bool IsNewDirectionValid(Vector2Int previousDirection, Vector2Int newDirection)
    {
        return !(newDirection == -previousDirection);
    }
*/
}




