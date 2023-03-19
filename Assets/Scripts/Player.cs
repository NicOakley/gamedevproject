using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{

    public static int gold = 0;
    public float health = 100f;
    private HealthBar HealthBar;
    public float atkDamage = 20f;

    // Player stats (given by base stats and items)
    public float atkStat;
    public float hpRegenStat;
    public float defStat; // chance to block damage completely


    // Start is called before the first frame update
    void Start()
    {
        // Set player stats
        atkStat = atkDamage;
        hpRegenStat = 0;
        defStat = 0;

        // Log player stats
        Debug.Log("Player stats: ");
        Debug.Log("Attack: " + atkStat);
        Debug.Log("Regen: " + hpRegenStat);
        Debug.Log("Defence: " + defStat);


        HealthBar = GetComponentInChildren<HealthBar>();
        //HealthBar.MAX_HEALTH = health; (was causing object reference error)
        //HealthBar.health = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}