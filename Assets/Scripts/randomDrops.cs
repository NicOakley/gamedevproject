using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomDrops : MonoBehaviour
{

    // Health bar
    public HealthBar HealthBar;

    // array of random drop prefabs
    public GameObject[] randomDropsArray;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponentInChildren<HealthBar>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if ( HealthBar.health <= 0) {
            Debug.Log("Rolling for random drop");
            // ten percent chance of dropping a random item
            if (Random.Range(0, 10) == 0) {
                // random number between 0 and 2
                int randomDrop = Random.Range(0, randomDropsArray.Length-1);
                // instantiate random drop
                Instantiate(randomDropsArray[randomDrop], new Vector3(transform.position.x,transform.position.y, -2), Quaternion.identity);
            }

            
        }
    }
}
