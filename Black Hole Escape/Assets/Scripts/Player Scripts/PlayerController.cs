using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float laneDistance = 3.0f; // Distance between lanes
    public float speed = 10f; // Speed of player movement
    private int currentLane = 1; // 0 = Left, 1 = Middle, 2 = Right
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleInput();
        MoveToTargetLane();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            ShiftLane(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            ShiftLane(1);
        }
    }

    private void ShiftLane(int direction)
    {
        // Update lane index within bounds
        currentLane = Mathf.Clamp(currentLane + direction, 0, 2);
        targetPosition = new Vector3(currentLane * laneDistance - laneDistance, transform.position.y, transform.position.z);
    }

    private void MoveToTargetLane()
    {
        // Smooth movement towards the target lane position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
