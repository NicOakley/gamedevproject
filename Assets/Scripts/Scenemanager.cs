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




    // Start is called before the first frame update
    void Start()
    {
        playerT = GameObject.Find("Player").transform;
        Debug.Log(roomsCompleted);
        Debug.Log(easyLevelStarted);
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    public void startEasyDungeon(){
        roomsCompleted = 0;
        medLevelStarted = false;
        easyLevelStarted = true;
        playerT.position = new Vector3(7f,-.62f,-3);
        SceneManager.LoadScene("easyRoom1");
    }

    public void startMedDungeon(){
        roomsCompleted = 0;
        easyLevelStarted = false;
        medLevelStarted = true;
        playerT.position = new Vector3(-7.282f,-1.17f,-3);
        SceneManager.LoadScene("medRoom1");
    }

    public void startHardDungeon(){
        roomsCompleted = 0;
        easyLevelStarted = false;
        medLevelStarted = false;
        hardLevelStarted = true;
        playerT.position = new Vector3(-.16f,-1.2f,-3);
        SceneManager.LoadScene("hardRoom1");
    }

    public void startBossDungeon(){
        roomsCompleted = 0;
        easyLevelStarted = false;
        medLevelStarted = false;
        hardLevelStarted = false;
        bossLevelStarted = true;
        playerT.position = new Vector3(-7.44f,-1.12f,-3);
        SceneManager.LoadScene("bossRoom1");
    }



    public void nextRoom(){
        roomsCompleted++;
        
        if( Scenemanager.easyLevelStarted == true){
            if( roomsCompleted == 1){
            playerT.position = new Vector3(.15f,-1.21f,-3);
            SceneManager.LoadScene("easyRoom2");
            }
            if( roomsCompleted == 2){
            playerT.position = new Vector3(7.51f,-.58f,-3);
            SceneManager.LoadScene("easyRoom3");
            }
            if( roomsCompleted == 3){
            Scenemanager.easyCompleted = true;
            Scenemanager.loadHub();
            }
        }



    if( Scenemanager.medLevelStarted == true){
            if( roomsCompleted == 1){
            playerT.position = new Vector3(1.68f,2.2f,-3);
            SceneManager.LoadScene("medRoom2");
            }
            if( roomsCompleted == 2){
            playerT.position = new Vector3(-.88f,-1.3f,-3);
            SceneManager.LoadScene("medRoom3");
            }
            if( roomsCompleted == 3){
            Scenemanager.medCompleted = true;
            Scenemanager.loadHub();
        }
        }


        if( Scenemanager.hardLevelStarted == true){
            if( roomsCompleted == 1){
            playerT.position = new Vector3(7.02f,-.62f,-3);
            SceneManager.LoadScene("hardRoom2");
            }
            if( roomsCompleted == 2){
            playerT.position = new Vector3(-.87f,-1.28f,-3);
            SceneManager.LoadScene("hardRoom3");
            }
            if( roomsCompleted == 3 ){
            Scenemanager.hardCompleted = true;
            Scenemanager.loadHub();
        }
    }

        if( Scenemanager.bossLevelStarted == true){
            Scenemanager.roomsCompleted = 0;
            Scenemanager.easyLevelStarted = false;
            Scenemanager.medLevelStarted = false;
            Scenemanager.hardLevelStarted = false;
            Scenemanager.bossLevelStarted = false;
            playerT.position = new Vector3(-.48f, -.11f, 0);
            Scenemanager.loadHub();
        }





    }

    public static void loadHub(){
        Scenemanager.roomsCompleted = 0;
        Scenemanager.easyLevelStarted = false;
        Scenemanager.medLevelStarted = false;
        Scenemanager.hardLevelStarted = false;
        Scenemanager.bossLevelStarted = false;
        playerT.position = new Vector3(-.48f, -.11f, 0);


        if(hardCompleted == true) {
            SceneManager.LoadScene("mainHub 4");
        }
        else if(medCompleted == true) {
            SceneManager.LoadScene("mainHub 3");
        }
        else if(easyCompleted == true) {
            SceneManager.LoadScene("mainHub 2");
        }
        else {
            SceneManager.LoadScene("mainHub 1");
        }
    }



}