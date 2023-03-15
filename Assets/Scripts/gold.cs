using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour
{

    public Transform goldTransform; 
    public Rigidbody2D goldRigidbody;
    public Transform playerPosition;


    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // move towards player
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.transform.position, 2f * Time.deltaTime);
    }


    // if gold collides with player

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            Player.gold++;
            Debug.Log("Player has picked up gold:" + Player.gold);

            // destroy gold
            Destroy(gameObject);
        }
    }
    
}
