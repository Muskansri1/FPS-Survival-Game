using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private CharacterController character_controller;

    private Vector3 move_direction;

    public float speed = 5f;
    private float gravity = 20f;

    public float jump_force = 10f;
    private float vertical_velocity;

    private void Awake()
    {
        character_controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveThePlayer();        
    }

    void MoveThePlayer()
    {
        move_direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));

        move_direction = transform.TransformDirection(move_direction);

        move_direction *= speed * Time.deltaTime;

        ApplyGravity();
       

        character_controller.Move(move_direction);

    }

    void ApplyGravity()
    {
        if (character_controller.isGrounded)
        {
            vertical_velocity -= gravity * Time.deltaTime;

            PlayerJump();
        }
        else
        {
            vertical_velocity -= gravity * Time.deltaTime;
        }
        move_direction.y = vertical_velocity * Time.deltaTime;
        
    }

    void PlayerJump()
    {
        if(character_controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            vertical_velocity = jump_force;
        }
    }
}
