using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.transform.position.y +3, transform.position.z);
    }
}
