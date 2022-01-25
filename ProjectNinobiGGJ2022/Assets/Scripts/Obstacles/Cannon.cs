using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private float timer = 0f;
    public float shootTimer = 2f;
    public float bulletSpeed = -500;
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    private GameObject bulletInstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootTimer)
        {
            timer = 0;
            bulletInstance = Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, 0));
        }

    }
}
