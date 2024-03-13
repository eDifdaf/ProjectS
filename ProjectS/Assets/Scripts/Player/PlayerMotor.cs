using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    private Vector3 curentVelocity;
    public float speed = 5f;



    public void Moving(Vector2 input)
    {
        Vector3 moveInDirection = Vector3.zero;
        moveInDirection.x = input.x;
        moveInDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveInDirection * speed) * Time.deltaTime);

    }
    
}
