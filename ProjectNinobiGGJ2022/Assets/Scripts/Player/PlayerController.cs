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

    public StepUp heavenFeet;
    public StepUp hellFeet;
    public GameObject heavenHead;
    public GameObject hellHead;

    [Header("Enablers/Disablers")] //For easily disabling player actions for level start/end events, UI events, etc.
    [HideInInspector] public bool disableMovement;
    [HideInInspector] public bool disableJump;

    [Header("Player Settings")]
    public float movementSpeed;
    public float inAirControl;
    public float jumpForce;
    public bool isJumping;
    public float coyoteTimer;

    [Header("Movement")]
    public float movementInput;
    public bool heavenGrounded;
    public bool hellGrounded;
    public float groundRay; //Length of ground check, make hidden once we figure out character dimensions.
    public LayerMask groundLayers;

    public float gravity;
    public float gravityScale;
    public float velocity;
    private float coyoteTimerCurrent;

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
            coyoteTimerCurrent = coyoteTimer;
        }
        else if (!Physics2D.Raycast(characterHeaven.transform.position, -Vector2.up, groundRay, groundLayers) && !Physics2D.Raycast(characterHell.transform.position, -Vector2.up, groundRay, groundLayers))
        {
            heavenGrounded = false;
            hellGrounded = false;
            if (!isJumping)
            {
                coyoteTimerCurrent -= Time.deltaTime;
            }
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
        //if (Physics2D.Raycast(characterHeaven.transform.position, Vector2.up, groundRay, groundLayers) || Physics2D.Raycast(characterHell.transform.position, Vector2.up, groundRay, groundLayers))
        //{
        //    Debug.Log("Bonked head");
        //    isJumping = false;
        //    velocity = -0.2f;
        //}
        if (Physics2D.CircleCast(heavenHead.transform.position, 0.5f, Vector2.up, 0.05f, groundLayers) || Physics2D.CircleCast(hellHead.transform.position, 0.5f, Vector2.up, 0.05f, groundLayers))
        {
            Debug.Log("Bonked head");
            isJumping = false;
            velocity = -0.3f;
        }
        else if (heavenFeet.CheckFeetOverlap() || hellFeet.CheckFeetOverlap()) //Pish player upwards if either character is currently intersecting with terrain object.
        {
            velocity += 0.35f;
        }
        

        if (isJumping && velocity < 0)
        {
            movementInput = Input.GetAxisRaw("Horizontal") * inAirControl;
        }
        else
        {
            movementInput = Input.GetAxisRaw("Horizontal"); //Get player input
        }

        if (Physics2D.BoxCast(characterHeaven.transform.position, new Vector2(1.05f, 1.7f), 0f, characterHeaven.transform.right, 0.05f, groundLayers)
            ||
            Physics2D.BoxCast(characterHell.transform.position, new Vector2(1.05f, 1.7f), 0f, characterHell.transform.right, 0.05f, groundLayers))
        {
            //Debug.Log("Hit collider to the right");
            if (movementInput > 0)
            {
                movementInput = -0.025f;
            }
        }
        if (Physics2D.BoxCast(characterHeaven.transform.position, new Vector2(1.05f, 1.7f), 0f, -characterHeaven.transform.right, 0.05f, groundLayers) 
                || 
                Physics2D.BoxCast(characterHell.transform.position, new Vector2(1.05f, 1.7f), 0f, -characterHell.transform.right, 0.05f, groundLayers))
        {
            //Debug.Log("Hit collider to the left");
            if (movementInput < 0)
            {
                movementInput = 0.025f;
            }
        }
        //else
        //{
            if (!disableMovement) //Translate horizontal input into movement.
            {
                characterHeaven.transform.Translate(new Vector3(movementInput, 0, 0) * movementSpeed * Time.deltaTime);
                characterHell.transform.Translate(new Vector3(movementInput, 0, 0) * movementSpeed * Time.deltaTime);
            }
        //}


        if (Input.GetButtonDown("Jump") && !disableJump && isJumping == false && coyoteTimerCurrent > 0f) //If player is able to and wants to jump.
        {
            coyoteTimerCurrent = 0f;
            isJumping = true;
            Jump();
        }
        if (Input.GetButtonUp("Jump") && isJumping && !heavenGrounded && !hellGrounded)
        {
            velocity = velocity * 0.5f;
            isJumping = false;
        }


        characterHeaven.transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
        characterHell.transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    }

    private void FixedUpdate()
    {
    }

    public void Jump()
    {
        velocity = jumpForce;
    }
}
