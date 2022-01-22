using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Script/Object Refs")]
    public GameObject characterHeaven;
    public Rigidbody2D heavenRB;
    public GameObject characterHell;
    public Rigidbody2D hellRB;

    [Header("Enablers/Disablers")] //For easily disabling player actions for level start/end events, UI events, etc.
    [HideInInspector] public bool disableMovement;
    [HideInInspector] public bool disableJump;

    [Header("Player Settings")]
    public float movementSpeed;
    public float jumpForce;
    public bool isJumping;

    [Header("Movement")]
    public float movementInput;
    public bool heavenGrounded;
    public bool hellGrounded;
    public float groundRay; //Length of ground check, make hidden once we figure out character dimensions.
    public LayerMask groundLayers;

    public float gravity;
    public float gravityScale;
    public float velocity;

    private void Awake()
    {
        heavenRB = characterHeaven.GetComponent<Rigidbody2D>();
        hellRB = characterHell.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //grounded check.
        if (Physics2D.Raycast(characterHeaven.transform.position, -Vector2.up, groundRay, groundLayers) || Physics2D.Raycast(characterHell.transform.position, -Vector2.up, groundRay, groundLayers))
        {
            heavenGrounded = true;
            hellGrounded = true;
            if (isJumping)
            {
                isJumping = false;
            }
        }
        else if (!Physics2D.Raycast(characterHeaven.transform.position, -Vector2.up, groundRay, groundLayers) && !Physics2D.Raycast(characterHell.transform.position, -Vector2.up, groundRay, groundLayers))
        {
            heavenGrounded = false;
            hellGrounded = false;
        }

        if(!hellGrounded && !heavenGrounded)
        {
            velocity += gravity * gravityScale * Time.deltaTime;
        }
        else if (!isJumping && heavenGrounded && hellGrounded)
        {
            velocity = 0;
        }

        //Above check
        if (Physics2D.Raycast(characterHeaven.transform.position, Vector2.up, groundRay, groundLayers) || Physics2D.Raycast(characterHell.transform.position, Vector2.up, groundRay, groundLayers))
        {
            Debug.Log("Bonked head");
            isJumping = false;
            velocity = -0.2f;
        }
        
        movementInput = Input.GetAxisRaw("Horizontal"); //Get player input

        if (Input.GetButtonDown("Jump") && !disableJump && heavenGrounded && hellGrounded) //If player is able to and wants to jump.
        {
            isJumping = true;
            Jump();
        }

        if (!disableMovement) //Translate horizontal input into movement.
        {
            characterHeaven.transform.Translate(new Vector3(movementInput, 0, 0) * movementSpeed * Time.deltaTime);
            characterHell.transform.Translate(new Vector3(movementInput, 0, 0) * movementSpeed * Time.deltaTime);
        }

        characterHeaven.transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
        characterHell.transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);

    }

    private void FixedUpdate()
    {
    }

    private void Jump()
    {
        velocity = jumpForce;
    }
}
