using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAttackCollider : MonoBehaviour
{

    private Rigidbody2D rb;
    private HealthBar playerHealthBar;

    float timer = 0;
    bool timerReached = false;


    // Start is called before the first frame update
    void Start()
    {
        playerHealthBar = GameObject.FindWithTag("Player").GetComponentInChildren<HealthBar>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // timer
         if (!timerReached) {
                timer += Time.deltaTime;
            }
        
            if (timer > 2f) {
                timerReached = true;
                GameObject.FindWithTag("attColliderFront").SetActive(true);
                timer = 0;
                timerReached = false;
            }
    }


    // collisions
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Player hit by boss");
            playerHealthBar.health -= 10;
            GameObject.FindWithTag("attColliderFront").SetActive(false);

        }
    }
}
