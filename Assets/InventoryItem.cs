using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Item item;
    public Transform playerPosition;

    [Header("UI")]
    public UnityEngine.UI.Image image;

    [HideInInspector] public Transform parentAfterDrag;

    void Start() {
        playerPosition = GameObject.Find("Player").transform;
    }

    void wrongItemType(){
        Destroy(gameObject);
        Instantiate(item.itemPrefab, playerPosition.position, Quaternion.identity);
    }
    


    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (parentAfterDrag.tag == "inventorySlot")
        {
            transform.SetParent(parentAfterDrag);
            image.raycastTarget = true;
        }

        else if (parentAfterDrag.tag == "dropZone")
        {
            // delete item
            Destroy(gameObject);
            // instantiate item on ground
            Instantiate(item.itemPrefab, playerPosition.position, Quaternion.identity);
            Debug.Log("Dropped");
        }


        else if (parentAfterDrag.tag == "equipHelmet"){
            if (item.itemType == "Helmet"){
                Debug.Log("Helmet equipped");
                transform.SetParent(parentAfterDrag);
                image.raycastTarget = true;
            } else wrongItemType();
        }
            
            else if (parentAfterDrag.tag == "equipChest"){
                if (item.itemType == "Chest"){
                    Debug.Log("Chest equipped");
                    transform.SetParent(parentAfterDrag);
                    image.raycastTarget = true;
                } else wrongItemType();
            }
    
            else if (parentAfterDrag.tag == "equipLegs"){
                if (item.itemType == "Legs"){
                    Debug.Log("Legs equipped");
                    transform.SetParent(parentAfterDrag);
                    image.raycastTarget = true;
                } else wrongItemType();
            }
    
            else if (parentAfterDrag.tag == "equipBoots"){
                if (item.itemType == "Boots"){
                    Debug.Log("Boots equipped");
                    transform.SetParent(parentAfterDrag);
                    image.raycastTarget = true;
                } else wrongItemType();
            }
    
            else if (parentAfterDrag.tag == "equipWeapon"){
                if (item.itemType == "Weapon"){
                    Debug.Log("Weapon equipped");
                    transform.SetParent(parentAfterDrag);
                    image.raycastTarget = true;
                } else wrongItemType();
            }
    
            else if (parentAfterDrag.tag == "equipShield"){
                if (item.itemType == "Shield"){
                    Debug.Log("Shield equipped");
                    transform.SetParent(parentAfterDrag);
                    image.raycastTarget = true;
                } else wrongItemType();
            }
    
    
            else if (parentAfterDrag.tag == "equipRing"){
                if (item.itemType == "Ring"){
                    Debug.Log("Ring equipped");
                    transform.SetParent(parentAfterDrag);
                    image.raycastTarget = true;
                } else wrongItemType();
            }

            else if (parentAfterDrag.tag == "equipBracelet") {
                if (item.itemType == "Bracelet") {
                    Debug.Log("Bracelet equipped");
                    transform.SetParent(parentAfterDrag);
                    image.raycastTarget = true;
                } else wrongItemType();
            }
    

        else wrongItemType();
    }
 }



