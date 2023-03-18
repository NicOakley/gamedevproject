using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{

    public Item item;
    public InventoryManager inventoryManager;
    

    // Start is called before the first frame update
    void Start()
    {
        // set inventory manager to the inventory manager in the scene
        inventoryManager = GameObject.Find("inventoryManager").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // when the player presses E
        if(Input.GetKeyDown(KeyCode.E)){
            // if the player is colliding with this item
            if(this.gameObject.GetComponent<Collider2D>().IsTouching(GameObject.Find("Player").GetComponent<Collider2D>())){
                // check if the inventory is full before adding the item
                if(inventoryManager.isFull() == false ){
                     inventoryManager.AddItem(item);
                     Destroy(this.gameObject);
                }
                else{
                    Debug.Log("Inventory is full");
                }
            }
        }

    
    }

}
