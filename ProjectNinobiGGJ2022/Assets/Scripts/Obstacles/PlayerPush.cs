using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float distance = 10;
    public LayerMask boxMask;

    private GameObject box;
    private PlayerPush playerC;
    private Rigidbody2D boxRigid;


    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(PlayerController));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.left * transform.localScale.x * distance);
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, distance, boxMask);

        if (hitRight.collider != null && hitRight.collider.CompareTag("Pushable"))
        {
            box = hitRight.collider.gameObject;
            boxRigid = box.GetComponent<Rigidbody2D>();
            boxRigid.velocity = new Vector2(+4, 0);
            Debug.Log("Moving Right");
        }
        if (hitLeft.collider != null && hitLeft.collider.CompareTag("Pushable"))
        {
            box = hitLeft.collider.gameObject;
            boxRigid = box.GetComponent<Rigidbody2D>();
            boxRigid.velocity = new Vector2(-4, 0);
            Debug.Log("Moving left");
        }
    }
}
