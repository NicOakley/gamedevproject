using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre : MonoBehaviour
{

    int health = 100;

    // get gold item
    public GameObject goldObject;
    public static int gold;

    public static int goldDropped;


    
    // Start is called before the first frame update
    void Start()
    {
        setHealth(0);
        
    }

    // fixed update
    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
    }

    void checkHealth()
    {
        if (health <= 0)
        {
            DropLoot();
            Destroy(gameObject);
        }

        else{ 
            Debug.Log("Ogre is still alive");
        }
    }

    void setHealth(int newHealth)
    {
        health = newHealth;
    }




    void DropLoot()
    {
        int rareLootChance = 5;
        int random = Random.Range(0, 100);

        // Always drops
        Ogre.goldDropped = dropGold(1,4);

        // Common loot drops
        if (random <= 25)
        {
            int commonLoot = Random.Range(0, 2);
            
            if (commonLoot == 0)
            {
                Debug.Log("Ogre dropped a potion");
            }

            if (commonLoot == 1)
            {
                Debug.Log("Ogre dropped a key");
            }
        }

        // Rare loot drops
        if (random >= 101 - rareLootChance)
        {
            // Random number between 0 and 2
            int rareLoot = Random.Range(0, 3);
            if (rareLoot == 0)
            {
                Debug.Log("Ogre dropped a sword");
            }
            if (rareLoot == 1)
            {
                Debug.Log("Ogre dropped a shield");
            }
            if (rareLoot == 2)
            {
                Debug.Log("Ogre dropped a helmet");
            }
        }

        

        
    }

    // Drop gold between range
    int dropGold(int low, int high)
    {
        int gold = Random.Range(low, high);
        Debug.Log("Ogre dropped " + gold + " gold");

        // Spawn gold
        Instantiate(goldObject, transform.position, Quaternion.identity);


        return gold;
    }

}
