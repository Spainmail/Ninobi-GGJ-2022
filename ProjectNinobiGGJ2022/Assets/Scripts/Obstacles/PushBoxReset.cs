using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBoxReset : MonoBehaviour
{

    public GameObject newLoc;
    public float timer = 0f;
    public float cooldownTimer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= cooldownTimer && Input.GetButtonDown("r"))    
        {
            timer = 0;
            this.gameObject.transform.position = newLoc.gameObject.transform.position;
        }
    }
}
