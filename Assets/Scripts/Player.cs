using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{


    public static int gold = 0;
    public float health = 100f;
    private HealthBar HealthBar;

    // Player stats (base)
    public float baseAtkDamage = 20f;
    public float baseDefStat = 0f; // chance to block damage completely

    // Player stats (equipment)
    public static float equipAtkDamage;
    public static float equipDefStat;

    // Player stats (total)
    public float atkStat;
    public float defStat;



    // Start is called before the first frame update
    void Start()
    {
        // Set player stats
        atkStat = baseAtkDamage + equipAtkDamage;
        defStat = baseDefStat + equipDefStat;

        // Log player stats
        Debug.Log("Player stats: ");
        Debug.Log("Attack: " + atkStat);
        Debug.Log("Defence: " + defStat);


        HealthBar = GetComponentInChildren<HealthBar>();
        HealthBar.MAX_HEALTH = health;
        HealthBar.health = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Player stats: ");
            Debug.Log("Attack: " + atkStat);
            Debug.Log("Defence: " + defStat);
        }
    }

    void FixedUpdate(){
        // update stats from equipment
        atkStat = baseAtkDamage + equipAtkDamage;
        defStat = baseDefStat + equipDefStat;
    }





}