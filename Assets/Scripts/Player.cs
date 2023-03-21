using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public static Transform playerT;


    // Start is called before the first frame update
    void Start()
    {
        playerT = GameObject.Find("Player").transform;

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

        if( HealthBar.health <= 0){

            string currentScene = SceneManager.GetActiveScene().name;

            HealthBar.health = 100;

            //easyRoom1, easyRoom2, easyRoom3, medRoom1, medRoom2, medRoom3, hardRoom1, hardRoom2, hardRoom3, bossRoom1

            // if scene is bossRoom1

            if(currentScene == "bossRoom1"){
                playerT.position = new Vector3(-7.44f,-1.12f,1f);
                SceneManager.LoadScene("bossRoom1");
            }

            // if scene is hardRoom1
            if(currentScene == "hardRoom1"){
                playerT.position = new Vector3(-.16f,-1.2f,1f);
                SceneManager.LoadScene("hardRoom1");
            }

            // if scene is medRoom1
            if(currentScene == "medRoom1"){
                playerT.position = new Vector3(-7.282f,-1.17f,1f);
                SceneManager.LoadScene("medRoom1");
            }

            // if scene is easyRoom1
            if(currentScene == "easyRoom1"){
                playerT.position = new Vector3(7f,-.62f,1f);
                SceneManager.LoadScene("easyRoom1");
            }

            // if scene is easyRoom2
            if(currentScene == "easyRoom2"){
                playerT.position = new Vector3(.15f,-1.21f,1f);
                SceneManager.LoadScene("easyRoom2");
            }

            // if scene is easyRoom3
            if(currentScene == "easyRoom3"){
                playerT.position = new Vector3(7.51f,-.58f,1f);
                SceneManager.LoadScene("easyRoom3");
            }

            // if scene is medRoom2
            if(currentScene == "medRoom2"){
                playerT.position = new Vector3(1.68f,2.2f,1f);
                SceneManager.LoadScene("medRoom2");
            }

            // if scene is medRoom3
            if(currentScene == "medRoom3"){
                playerT.position = new Vector3(-.88f,-1.3f,1f);
                SceneManager.LoadScene("medRoom3");
            }

            // if scene is hardRoom2
            if(currentScene == "hardRoom2"){
                playerT.position = new Vector3(7.02f,-.62f,1f);
                SceneManager.LoadScene("hardRoom2");
            }

            // if scene is hardRoom3
            if(currentScene == "hardRoom3"){
                playerT.position = new Vector3(-.87f,-1.28f,1f);
                SceneManager.LoadScene("hardRoom3");
            }

            
        }
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