using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{

    public static bool easyLevelStarted = false;
    public static bool medLevelStarted = false;
    public static bool hardLevelStarted = false;
    public static bool bossLevelStarted = false;

    public static bool easyCompleted = false;
    public static bool medCompleted = false;
    public static bool hardCompleted = false;

    public static int roomsCompleted = 0;

    public static int dungeonsCompleted = 0;

    // player transform
    public static Transform playerT;
    public static HealthBar playerHealthBar;




    // Start is called before the first frame update
    void Start()
    {
        //set levelExit to false

        playerHealthBar = GameObject.FindWithTag("Player").GetComponentInChildren<HealthBar>();
        playerT = GameObject.Find("Player").transform;
        Debug.Log(roomsCompleted);
        Debug.Log(easyLevelStarted);
    }

    // Update is called once per frame



    public void startEasyDungeon(){
        playerHealthBar.health = 100f;
        roomsCompleted = 0;
        medLevelStarted = false;
        easyLevelStarted = true;
        playerT.position = new Vector3(7f,-.62f,1f);
        SceneManager.LoadScene("easyRoom1");
    }

    public void startMedDungeon(){
        playerHealthBar.health = 100f;
        roomsCompleted = 0;
        easyLevelStarted = false;
        medLevelStarted = true;
        playerT.position = new Vector3(-7.282f,-1.17f,1f);
        SceneManager.LoadScene("medRoom1");
    }

    public void startHardDungeon(){
        playerHealthBar.health = 100f;
        roomsCompleted = 0;
        easyLevelStarted = false;
        medLevelStarted = false;
        hardLevelStarted = true;
        playerT.position = new Vector3(-.16f,-1.2f,1f);
        SceneManager.LoadScene("hardRoom1");
    }

    public void startBossDungeon(){
        playerHealthBar.health = 100f;
        roomsCompleted = 0;
        easyLevelStarted = false;
        medLevelStarted = false;
        hardLevelStarted = false;
        bossLevelStarted = true;
        playerT.position = new Vector3(-7.44f,-1.12f,1f);
        SceneManager.LoadScene("bossRoom1");
    }



    public void nextRoom(){
        roomsCompleted++;
        
        if( Scenemanager.easyLevelStarted == true){
            if( roomsCompleted == 1){
                playerHealthBar.health = 100f;
            playerT.position = new Vector3(.15f,-1.21f,1f);
            SceneManager.LoadScene("easyRoom2");
            }
            if( roomsCompleted == 2){
                playerHealthBar.health = 100f;
            playerT.position = new Vector3(7.51f,-.58f,1f);
            SceneManager.LoadScene("easyRoom3");
            }
            if( roomsCompleted == 3){
                playerHealthBar.health = 100f;
            Scenemanager.easyCompleted = true;
            Scenemanager.loadHub();
            }
        }



    if( Scenemanager.medLevelStarted == true){
            if( roomsCompleted == 1){
                playerHealthBar.health = 100f;
            playerT.position = new Vector3(1.68f,2.2f,1f);
            SceneManager.LoadScene("medRoom2");
            }
            if( roomsCompleted == 2){
                playerHealthBar.health = 100f;
            playerT.position = new Vector3(-.88f,-1.3f,1f);
            SceneManager.LoadScene("medRoom3");
            }
            if( roomsCompleted == 3){
                playerHealthBar.health = 100f;
            Scenemanager.medCompleted = true;
            Scenemanager.loadHub();
        }
        }


        if( Scenemanager.hardLevelStarted == true){
            if( roomsCompleted == 1){
                playerHealthBar.health = 100f;
            playerT.position = new Vector3(7.02f,-.62f,1f);
            SceneManager.LoadScene("hardRoom2");
            }
            if( roomsCompleted == 2){
                playerHealthBar.health = 100f;
            playerT.position = new Vector3(-.87f,-1.28f,1f);
            SceneManager.LoadScene("hardRoom3");
            }
            if( roomsCompleted == 3 ){
                playerHealthBar.health = 100f;
            Scenemanager.hardCompleted = true;
            Scenemanager.loadHub();
        }
    }

        if( Scenemanager.bossLevelStarted == true){
            playerHealthBar.health = 100f;
            Scenemanager.roomsCompleted = 0;
            Scenemanager.easyLevelStarted = false;
            Scenemanager.medLevelStarted = false;
            Scenemanager.hardLevelStarted = false;
            Scenemanager.bossLevelStarted = false;
            playerT.position = new Vector3(-.48f, -.11f, 1f);
            Scenemanager.loadHub();
        }





    }

    public static void loadHub(){
        playerHealthBar.health = 100f;
        Scenemanager.roomsCompleted = 0;
        Scenemanager.easyLevelStarted = false;
        Scenemanager.medLevelStarted = false;
        Scenemanager.hardLevelStarted = false;
        Scenemanager.bossLevelStarted = false;
        playerT.position = new Vector3(-.48f, -.11f, 1f);


        if(hardCompleted == true) {
            playerHealthBar.health = 100f;
            SceneManager.LoadScene("mainHub 4");
        }
        else if(medCompleted == true) {
            playerHealthBar.health = 100f;
            SceneManager.LoadScene("mainHub 3");
        }
        else if(easyCompleted == true) {
            playerHealthBar.health = 100f;
            SceneManager.LoadScene("mainHub 2");
        }
        else {
            playerHealthBar.health = 100f;
            SceneManager.LoadScene("mainHub 1");
        }
    }



}