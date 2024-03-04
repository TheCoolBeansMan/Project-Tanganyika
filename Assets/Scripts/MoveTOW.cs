using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Android;

public class MoveTOW : MonoBehaviour
{
    public float moveDistance = 1.0f;
    public float moveSpeed = 5.0f;
    public GameObject objectToMove;

    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        if (objectToMove == null)
        {
            objectToMove = gameObject; // If no object is specified, move the current object
        }

        targetPosition = objectToMove.transform.position;
    }

    void Update()
    {
        if (!isMoving)
        {
            // Check for input and set the target position accordingly
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                targetPosition += Vector3.up * moveDistance;
                MoveToTarget();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                targetPosition += Vector3.down * moveDistance;
                MoveToTarget();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                targetPosition += Vector3.left * moveDistance;
                MoveToTarget();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                targetPosition += Vector3.right * moveDistance;
                MoveToTarget();
            }
        }
    }

    void MoveToTarget()
    {
        float minX = -4.5f; // 16x16 grid, assuming each grid unit is 1 unit in size
        float maxX = 4.5f;
        float minY = -4.5f;
        float maxY = 4.5f;

        // Clamp the target position within the boundaries
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX + 0.5f, maxX - 0.5f);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY + 0.5f, maxY - 0.5f);

        isMoving = true;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            // Move towards the target position
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if we've reached the target position
            if (objectToMove.transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }
}
