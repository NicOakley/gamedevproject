using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{


    public static int gold = 0;
    public float health = 100f;
    [HideInInspector] public HealthBar HealthBar;

    // Player stats (base)
    public float baseAtkDamage = 20f;
    public float baseDefStat = 0f; // chance to block damage completely

    // Player stats (equipment)
    public static float equipAtkDamage;
    public static float equipDefStat;

    // Player stats (total)
    public float atkStat;
    public float defStat;


    public Scenemanager scenemanager;




    // Start is called before the first frame update
    void Start()
    {
        // find with tag scenemanager


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


    void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.tag == "easyDoor"){
            scenemanager.startEasyDungeon();
        }

        if(other.gameObject.tag == "medDoor"){
            scenemanager.startMedDungeon();
        }

        if(other.gameObject.tag == "hardDoor"){
            scenemanager.startHardDungeon();
        }

        if(other.gameObject.tag == "bossDoor"){
            scenemanager.startBossDungeon();
        }

        if(other.gameObject.tag == "levelExit"){
            Debug.Log("Level exit collision");
            scenemanager.nextRoom();
        }

        if(other.gameObject.tag == "boss"){
            Debug.Log("Boss collision");
        }
    }





}