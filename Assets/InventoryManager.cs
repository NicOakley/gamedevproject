using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{


    public Transform playerPosition;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public GameObject inventoryUI;

    void Start() {
        playerPosition = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // if inventoryUI is active, deactivate it
            if (inventoryUI.activeSelf)
            {
                inventoryUI.SetActive(false);
            }
            // if inventoryUI is not active, activate it
            else
            {
                inventoryUI.SetActive(true);
            }

            
        }
    }



    public void AddItem(Item item) {

        for (int i = 0; i < inventorySlots.Length; i++){
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null) {
                SpawnNewItem(item, slot);
                return;
            }
        }

    }




    public bool isFull(){
        for (int i = 0; i < inventorySlots.Length; i++){
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null) {
                return false;
            }
        }
        return true;
    }

    void SpawnNewItem(Item item, InventorySlot slot) {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryitem = newItemGo.GetComponent<InventoryItem>();
        inventoryitem.InitialiseItem(item);
    }
}
