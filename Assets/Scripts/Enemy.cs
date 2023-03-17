using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] private float moveSpeed = .5f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Transform target;
    private SpriteRenderer sr;
    private float damageTaken;
    private HealthBar HealthBar;


    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponentInChildren<HealthBar>();
        HealthBar.MAX_HEALTH = health;
        HealthBar.health = health;

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
        if (target){
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    

        // if x velocity is greater than 0 (moving right)
        if (rb.velocity.x > 0) {
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
        if (collision.gameObject.tag == "Player") {
            damageTaken = collision.gameObject.GetComponent<Player>().atkDamage;
            HealthBar.health = HealthBar.health - damageTaken;
        }

        if (HealthBar.health <= 0)
            Destroy(gameObject);
    }
}
