using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject {


    public Sprite image;
    public GameObject itemPrefab;

    public string itemName;
    public string itemType;

    public float levelReq;

    public float atkStat;
    public float hpRegenStat;
    public float defStat;





}