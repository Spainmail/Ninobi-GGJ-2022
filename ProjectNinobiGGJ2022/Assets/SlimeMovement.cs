using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public bool movingLeft = true;
    public float movingTime = 1;
    public float movingTimer;
    public float movementSpeed = 1;
    public SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        movingTimer = movingTime;
    }

    // Update is called once per frame
    void Update()
    {
        movingTimer -= Time.deltaTime;
        if(movingLeft)
        {
            this.transform.Translate(new Vector3(1, 0, 0) * movementSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.Translate(new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime);
        }
        if(movingTimer < 0)
        {
            if (movingLeft)
            {
                movingLeft = false;
                mySpriteRenderer.flipX = false;
            }
            else
            {
                movingLeft = true;
                mySpriteRenderer.flipX = true;
            }
            movingTimer = movingTime;
        }
    }
}
