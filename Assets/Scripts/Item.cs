using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject {
    
    [Header("Only Gameplay")]
    public ItemType type;
    public actionType action;

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;

    public enum ItemType { 
        Consumable,
        Weapon,
        Armor,
        Key,
        Gold
    }

    public enum actionType {
        None,
        Heal,
        Buff,
        Unlock
    }

}