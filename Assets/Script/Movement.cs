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
    private float gridTimerMax = 1f; // Player se moverá cada segundo

    private void Awake()
    {
        startGridPosition = new Vector2Int(0, 0);
        gridPosition = startGridPosition;
        gridMoveDirection = new Vector2Int(1, 1); // Right-up por defecto
    }

    private void Update()
    {
        GridMovement();
        RightUp();
        RightDown();
        LeftUp();
        LeftDown();
    }

    private void RightUp()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            gridMoveDirection.x = 1;
            gridMoveDirection.y = 1;
        } 
    }

    private void RightDown()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            gridMoveDirection.x = 1;
            gridMoveDirection.y = -1;
        }
    }

    private void LeftUp()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gridMoveDirection.x = -1;
            gridMoveDirection.y = 1;
        }
    }
    private void LeftDown()
    {
        if (Input.GetKeyDown(KeyCode.A))
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



