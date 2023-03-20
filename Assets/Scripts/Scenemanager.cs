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

        if(Input.GetKeyDown(KeyCode.O)){
            nextRoom();
        }
        
    }

    public void startEasyDungeon(){
        roomsCompleted = 0;
        medLevelStarted = false;
        easyLevelStarted = true;
        SceneManager.LoadScene("easyRoom1");
    }

    public void startMedDungeon(){
        roomsCompleted = 0;
        easyLevelStarted = false;
        medLevelStarted = true;
        SceneManager.LoadScene("medRoom1");
    }

    public void startHardDungeon(){
        roomsCompleted = 0;
        easyLevelStarted = false;
        medLevelStarted = false;
        hardLevelStarted = true;
        SceneManager.LoadScene("hardRoom1");
    }

    public void startBossDungeon(){
        roomsCompleted = 0;
        easyLevelStarted = false;
        medLevelStarted = false;
        hardLevelStarted = false;
        bossLevelStarted = true;
        SceneManager.LoadScene("bossRoom1");
    }



    public void nextRoom(){
        roomsCompleted++;
        
        if( Scenemanager.easyLevelStarted == true){
            if( roomsCompleted == 1){
            playerT.position = new Vector3(.4f,-.46f,0);
            SceneManager.LoadScene("easyRoom2");
            }
            if( roomsCompleted == 2){
            playerT.position = new Vector3(-.164f,-1.3f,0);
            SceneManager.LoadScene("easyRoom3");
            }
            if( roomsCompleted == 3){
            SceneManager.LoadScene("easyRoom4");
             }
            if( roomsCompleted == 4){
            playerT.position = new Vector3(-.86f, -1.288f, 0);
            SceneManager.LoadScene("easyRoom5");
            }
            if( roomsCompleted == 5){
            Scenemanager.roomsCompleted = 0;
            Scenemanager.easyLevelStarted = false;
            Scenemanager.dungeonsCompleted = 1;
            playerT.position = new Vector3(-.48f, -.11f, 0);
            SceneManager.LoadScene("mainHub 2");
        }
        }



    if( Scenemanager.medLevelStarted == true){
            if( roomsCompleted == 1){
            playerT.position = new Vector3(.4f,-.46f,0);
            SceneManager.LoadScene("medRoom2");
            }
            if( roomsCompleted == 2){
            playerT.position = new Vector3(-.164f,-1.3f,0);
            SceneManager.LoadScene("medRoom3");
            }
            if( roomsCompleted == 3){
            SceneManager.LoadScene("medRoom4");
             }
            if( roomsCompleted == 4){
            playerT.position = new Vector3(-.86f, -1.288f, 0);
            SceneManager.LoadScene("medRoom5");
            }
            if( roomsCompleted == 5){
            Scenemanager.roomsCompleted = 0;
            Scenemanager.easyLevelStarted = false;
            Scenemanager.dungeonsCompleted = 2;
            playerT.position = new Vector3(-.48f, -.11f, 0);
            SceneManager.LoadScene("mainHub 3");
        }
        }


        if( Scenemanager.hardLevelStarted == true){
            if( roomsCompleted == 1){
            playerT.position = new Vector3(.4f,-.46f,0);
            SceneManager.LoadScene("hardRoom2");
            }
            if( roomsCompleted == 2){
            playerT.position = new Vector3(-.164f,-1.3f,0);
            SceneManager.LoadScene("hardRoom3");
            }
            if( roomsCompleted == 3){
            SceneManager.LoadScene("hardRoom4");
             }
            if( roomsCompleted == 4){
            playerT.position = new Vector3(-.86f, -1.288f, 0);
            SceneManager.LoadScene("hardRoom5");
            }
            if( roomsCompleted == 5 ){
            Scenemanager.roomsCompleted = 0;
            Scenemanager.easyLevelStarted = false;
            Scenemanager.medLevelStarted = false;
            Scenemanager.hardLevelStarted = false;
            Scenemanager.dungeonsCompleted = 3;
            playerT.position = new Vector3(-.48f, -.11f, 0);
            SceneManager.LoadScene("mainHub 4");
        }
    }

        if( Scenemanager.bossLevelStarted == true){
            Scenemanager.roomsCompleted = 0;
            Scenemanager.easyLevelStarted = false;
            Scenemanager.medLevelStarted = false;
            Scenemanager.hardLevelStarted = false;
            Scenemanager.bossLevelStarted = false;
            Scenemanager.dungeonsCompleted = 4;
            playerT.position = new Vector3(-.48f, -.11f, 0);
            SceneManager.LoadScene("mainHub 5");
        }





    }



}