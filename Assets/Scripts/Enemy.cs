using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    [SerializeField] float moveSpeed = .5f;
    Rigidbody2D rb;
    Vector2 moveDirection;
    Transform target;
    SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Protect").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            Vector2 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
        
    }

    void FixedUpdate() {
        if(target){
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    

    // if x velocity is greater than 0 (moving right)
    if(rb.velocity.x > 0) {
        // flip sprite to face right
        sr.flipX = true;
    }

    // if x velocity is less than 0 (moving left)
    if(rb.velocity.x < 0) {
        // flip sprite to face left
        sr.flipX = false;
    }

    }

    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("collision in enemy1 script");
        if(collision.gameObject.tag == "Player") {
            Destroy(this.gameObject);
        }
    }

}
