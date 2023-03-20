using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{

    public bool easyLevelStarted = false;
    public static int roomsCompleted = 0;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(roomsCompleted);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)){
            nextRoom();
        }


        if(Input.GetKeyDown(KeyCode.I)){
            startEasyDungeon();
        }
        
    }

    public void startEasyDungeon(){
        easyLevelStarted = true;
        SceneManager.LoadScene("easyRoom1");
    }


    public static void nextRoom(){
        roomsCompleted++;
        
        if( roomsCompleted == 1){
            SceneManager.LoadScene("easyRoom2");
        }
        if( roomsCompleted == 2){
            SceneManager.LoadScene("easyRoom3");
        }
        if( roomsCompleted == 3){
            SceneManager.LoadScene("easyRoom4");
        }
        if( roomsCompleted == 4){
            SceneManager.LoadScene("easyRoom5");
        }
        if( roomsCompleted == 5){
            SceneManager.LoadScene("mainHub 1");
        }
    }



}