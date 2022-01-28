using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public PlayerController player;
    public GameObject pauseScreenHeaven;
    public GameObject pauseScreenHell;
    public bool paused;

    public void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        if (paused == true)
        {
            player.disableMovement = false;
            player.disableJump = false;
            player.disableCollision = false;
            Time.timeScale = 1;
            pauseScreenHeaven.SetActive(false);
            pauseScreenHell.SetActive(false);
            paused = false;
        }
        else
        {
            player.disableMovement = true;
            player.disableJump = true;
            player.disableCollision = true;
            Time.timeScale = 0;
            pauseScreenHeaven.SetActive(true);
            pauseScreenHell.SetActive(true);
            paused = true;
        }
    }
}
