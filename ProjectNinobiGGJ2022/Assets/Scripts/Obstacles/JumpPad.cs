using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    PlayerController playerC;
    Rigidbody2D playerB;
    public float upwardVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("Player"))
        {
            playerB = Col.gameObject.GetComponent<Rigidbody2D>();
            playerC = Col.gameObject.GetComponentInParent<PlayerController>();
            playerC.velocity = upwardVelocity;
        }
    }
}
