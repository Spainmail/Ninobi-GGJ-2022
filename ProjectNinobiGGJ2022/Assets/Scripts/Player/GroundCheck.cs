using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGround = false;
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
        if (Col.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    public void OnTriggerExit2D(Collider2D Col)
    {
        if (Col.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
