using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyScanner : MonoBehaviour
{

    public GameObject levelExit;
    public Vector3 levelExitPos;
    bool door = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if there are no enemies left, activate levelExit
        if (GameObject.FindWithTag("Enemy1") == null && door == false) {
            door = true;

            if(SceneManager.GetActiveScene().name == "easyRoom1")
            Instantiate(levelExit, levelExitPos, Quaternion.identity);

            else if (SceneManager.GetActiveScene().name == "easyRoom2")
            Instantiate(levelExit, levelExitPos, Quaternion.identity);

            else if (SceneManager.GetActiveScene().name == "easyRoom3")
            Instantiate(levelExit, levelExitPos, Quaternion.identity);

            else if (SceneManager.GetActiveScene().name == "medRoom1")
            Instantiate(levelExit, levelExitPos, Quaternion.identity);

            else if (SceneManager.GetActiveScene().name == "medRoom2")
            Instantiate(levelExit, levelExitPos, Quaternion.identity);

            else if (SceneManager.GetActiveScene().name == "medRoom3")
            Instantiate(levelExit, levelExitPos, Quaternion.identity);

            else if (SceneManager.GetActiveScene().name == "hardRoom1")
            Instantiate(levelExit, levelExitPos, Quaternion.identity);

            else if (SceneManager.GetActiveScene().name == "hardRoom2")
            Instantiate(levelExit, levelExitPos, Quaternion.identity);

            else if (SceneManager.GetActiveScene().name == "hardRoom3")
            Instantiate(levelExit, levelExitPos, Quaternion.identity);

            else if (SceneManager.GetActiveScene().name == "bossRoom1")
            Instantiate(levelExit, levelExitPos, Quaternion.identity);
        }
        
    }
}
