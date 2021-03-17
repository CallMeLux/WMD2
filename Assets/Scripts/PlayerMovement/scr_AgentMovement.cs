﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_AgentMovement : MonoBehaviour
{
    CharacterController controller;
    public float rotationSpeed, movementSpeed, gravity = 20;
    Vector3 movementVector = Vector3.zero;
    public float jumpHeight = 3f;
    private float desiredRotationAngle = 0;

    private float inputVerticalDirection;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void HandleMovement(Vector2 input)
    {
        if (controller.isGrounded)
        {
            if(input.y != 0)
            {
                if(input.y > 0)
                {
                    inputVerticalDirection = Mathf.CeilToInt(input.y);
                }
                else
                {
                    inputVerticalDirection = Mathf.FloorToInt(input.y);
                }
                movementVector = input.y * transform.forward * movementSpeed;
            }
            else
            {
                movementVector = Vector3.zero;
            }
        }
    }

    public void HandleMovementDirection(Vector3 direction)
    {
        desiredRotationAngle = Vector3.Angle(transform.forward, direction);
        var crossProduct = Vector3.Cross(transform.forward, direction).y;
        if (crossProduct < 0)
        {
            desiredRotationAngle *= -1;
        }
    }

    private void RotateAgent()
    {
        if (desiredRotationAngle > 10 || desiredRotationAngle < -10)
        {
            transform.Rotate(Vector3.up * desiredRotationAngle * rotationSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            
            if(Input.GetButtonDown("Jump"))
        {
            movementVector.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
            
        }
            if (movementVector.magnitude > 0)
            {
                RotateAgent();
            }
        }
        movementVector.y -= gravity;
        controller.Move(movementVector * Time.deltaTime);
        Debug.Log("y velocity " + movementVector.y);
    }
}
