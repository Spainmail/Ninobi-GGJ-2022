using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public PlayerController players;
    public bool teleporting;
    public float teleportSpeed;
    public float teleportationProgressCurrent;

    public GameObject playerHeaven;
    public GameObject playerHell;

    public GameObject originPointPrefab;
    private GameObject originPointHeaven;
    private GameObject originPointHell;

    public GameObject latestCheckpointHeaven;
    public GameObject latestCheckpointHell;

    public ParticleSystem explodeVFXHeaven;
    public ParticleSystem explodeVFXHell;
    public GameObject teleportationParticlesHeaven;
    public GameObject teleportationParticlesHell;

    private void Awake()
    {
        players = FindObjectOfType<PlayerController>();
    }

    public void SetLatestCheckpoint(GameObject newCheckpoint, bool hell)
    {
        if (hell == true)
        {
            latestCheckpointHell = newCheckpoint;
        }
        else
        {
            latestCheckpointHeaven = newCheckpoint;
        }
    }

    public void TeleportPlayers(bool death) //death to decide whether particles should play. Do not set to true on level restart, etc.
    {
        Debug.Log("Teleporting to checkpoint");

        originPointHeaven = Instantiate(originPointPrefab, playerHeaven.transform.position, Quaternion.identity); //Set point from which to lerp towards checkpoint.
        originPointHell = Instantiate(originPointPrefab, playerHell.transform.position, Quaternion.identity); //Set point from which to lerp towards checkpoint.

        playerHeaven.GetComponent<SpriteRenderer>().enabled = false; //Turn off player sprite.
        playerHell.GetComponent<SpriteRenderer>().enabled = false; //Turn off player sprite.

        //Instantiate(explodeVFXHeaven, playerHeaven.transform.position, Quaternion.identity); //Instantiate explosion effect.
        //Instantiate(explodeVFXHell, playerHell.transform.position, Quaternion.identity); //Instantiate explosion effect.

        //teleportationParticlesHeaven.SetActive(true);
        //teleportationParticlesHell.SetActive(true);

        teleportationProgressCurrent = 0;
        teleporting = true;
    }

    private void FixedUpdate()
    {
        if (teleporting == true)
        {
            if (playerHeaven.transform.position == latestCheckpointHeaven.transform.position || playerHell.transform.position == latestCheckpointHell.transform.position)
            {
                Debug.Log("Arrived at teleportation target.");
                //Stop lerping and reinstate player + input.

                Destroy(originPointHeaven); //Destroy instantiated objects.
                Destroy(originPointHell);

                playerHeaven.GetComponent<SpriteRenderer>().enabled = true; //Turn off player sprite.
                playerHell.GetComponent<SpriteRenderer>().enabled = true; //Turn off player sprite.

                teleporting = false;

                players.DisableInput(false, false, false);
            }
            else //Continue lerping.
            {
                playerHeaven.transform.position = Vector3.Lerp(originPointHeaven.transform.position, latestCheckpointHeaven.transform.position, teleportationProgressCurrent);
                playerHell.transform.position = Vector3.Lerp(originPointHell.transform.position, latestCheckpointHell.transform.position, teleportationProgressCurrent);
            }
            teleportationProgressCurrent += Time.deltaTime * teleportSpeed;
        }
    }
}
