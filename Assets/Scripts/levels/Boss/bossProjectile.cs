using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossProjectile : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed;
    public Transform playerPos;
    public Transform projectilePos;

    private float targetX;
    private float targetY;



    // Start is called before the first frame update
    void Start()
    {
        projectilePos = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.Find("Player").transform;

        targetX = playerPos.position.x;
        targetY = playerPos.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        // create force in the direction of the player
        Vector2 direction = new Vector2(targetX, targetY) - rb.position;
        direction.Normalize();
        rb.velocity = direction * moveSpeed;

        // delete the projectile if it reaches the target within a certain range
        if (Mathf.Abs(projectilePos.position.x - targetX) < .1f && Mathf.Abs(projectilePos.position.y - targetY) < .1f) {
            Destroy(gameObject);
        }
        
        
        
    }


    // collisions
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Player hit by projectile");
            Destroy(gameObject);
        }
    }
}
