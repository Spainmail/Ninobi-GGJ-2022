using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killbox : MonoBehaviour
{

    private GameObject[] players;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.CompareTag("Player"))
        {
            for(int i = 0; i < players.Length; i++)
            {
                //Destroy(this.gameObject);
                playerController.DisableInput(true, true, true);
            }
        }
    }
}
