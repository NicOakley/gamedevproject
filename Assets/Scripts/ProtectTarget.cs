using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectTarget : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() 
    {

    }

    private void OnCollisionEnter2D(Collision2D other) {
        // If collision is with enemy1
        if (other.gameObject.tag == "Enemy1") {
            // take damage
            ProtectHealthBar.health = ProtectHealthBar.health - 10;
            // if health is 0
            if (ProtectHealthBar.health <= 0) {
                // destroy self
                Destroy(gameObject);
            }
        }
    }
}
