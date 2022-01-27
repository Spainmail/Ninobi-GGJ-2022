using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public TeleportPlayer players;
    public bool hell; //Is this checkpoint in hell screen?

    private void Awake()
    {
        players = FindObjectOfType<TeleportPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //Set checkpoint transform to TeleportPlayer's heaven/hell variable.
    {
        if (collision.tag == "Player")
        {
            if (hell == true)
            {
                players.SetLatestCheckpoint(this.gameObject, true);
            }
            else
            {
                players.SetLatestCheckpoint(this.gameObject, false);
            }
        }
    }
}
