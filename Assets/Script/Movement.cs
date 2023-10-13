using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Player's movement

    private Vector2Int gridPosition;
    private Vector2Int startGridPosition;
    private Vector2Int gridMoveDirection;

    private float horizontalInput;
    private float verticalInput;

    private float gridTimer;
    private float gridTimerMax = 0.5f; // Player se mover� cada medio segundo

    private void Awake()
    {
        startGridPosition = new Vector2Int(0, 0);
        gridPosition = startGridPosition;
        gridMoveDirection = new Vector2Int(0, 1); // Direcci�n arriba por defecto
    }

    private void Update()
    {
        GridMovement();  
    }

    private void HandleMoveDirection()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Cambio direcci�n hacia arriba
        if (verticalInput > 0) // Si he pulsado hacia arriba (W o Flecha Arriba)
        {
            if (gridMoveDirection.x != 0) // Si iba en horizontal
            {
                // Cambio la direcci�n hacia arriba (0,1)
                gridMoveDirection.x = 0;
                gridMoveDirection.y = 1;
            }
        }

        // Cambio direcci�n hacia abajo
        // Input es abajo?
        if (verticalInput < 0)
        {
            // Mi direcci�n hasta ahora era horizontal
            if (gridMoveDirection.x != 0)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }

        // Cambio direcci�n hacia derecha
        if (horizontalInput > 0)
        {
            if (gridMoveDirection.y != 0)
            {
                gridMoveDirection.x = 1;
                gridMoveDirection.y = 0;
            }
        }

        // Cambio direcci�n hacia izquierda
        if (horizontalInput < 0)
        {
            if (gridMoveDirection.y != 0)
            {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
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



