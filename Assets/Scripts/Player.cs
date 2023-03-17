using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    public InventoryManager inventoryManager;
    public Item item;

    public static int gold = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupItem(Item item) {
        inventoryManager.AddItem(item);
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "GroundItem"){
            Debug.Log("Picked up item");
            PickupItem(item);
            Destroy(other.gameObject);
        }
    }

}
