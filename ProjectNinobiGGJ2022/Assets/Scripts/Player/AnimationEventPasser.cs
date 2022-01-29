using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventPasser : MonoBehaviour
{
    public PlayerController playerC;
    public GameObject GroundCheck;
    // Start is called before the first frame update
    void Start()
    {
        playerC = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void stepHeaven()
    {
        if(GroundCheck.GetComponent<GroundCheck>().isGround == true)
        {
            playerC.stepHeaven();
        }
    }
        public void stepHell()
    {
        if(GroundCheck.GetComponent<GroundCheck>().isGround == true)
        {
            playerC.stepHell();
        }
    }
}
