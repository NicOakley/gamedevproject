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
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);

        if (parentAfterDrag.tag == "dropZone")
        {
            // delete item
            Destroy(gameObject);
            // instantiate item on ground
            Instantiate(item.itemPrefab, playerPosition.position, Quaternion.identity);
            Debug.Log("Dropped");
        }
    }


}
