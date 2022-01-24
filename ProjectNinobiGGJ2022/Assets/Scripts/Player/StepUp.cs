using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepUp : MonoBehaviour
{
    public PlayerController playerController;
    private CircleCollider2D feetCollider;
    public LayerMask groundMask;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        feetCollider = GetComponent<CircleCollider2D>();
    }

    public bool CheckFeetOverlap()
    {
        if (Physics2D.OverlapCircle(transform.position, feetCollider.radius, groundMask))
        {
            Debug.Log("Feet inside terrain!");
            return true;
        }
        else
        {
            return false;
        }
    }
}
