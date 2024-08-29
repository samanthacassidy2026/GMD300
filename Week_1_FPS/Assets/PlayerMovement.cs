using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public PlayerControls playerControls;
    public Vector2 movement;
    CharacterController characterController;
    [SerializeField] float speed = 10f;

    private void Awake()
    {
        
        playerControls = new PlayerControls();

        playerControls.Player.Movement.performed+=ctx=>movement = ctx.ReadValue<Vector2>();

        characterController = GetComponent<CharacterController>();

        playerControls.Player.Jump.performed+= _u =>Jump();


    }
    void Update()
    {

        //Debug.Log(movement);

        Vector3 playerVelocity = (transform.right * movement.x + transform.forward * movement.y) * speed;

        characterController.Move(playerVelocity*Time.deltaTime);

    }

    void Jump()
    {

        Debug.Log("Jump!");

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
