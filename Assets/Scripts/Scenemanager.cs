using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if scene name is "Tutorial"
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            // if input is "p"
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("Loading MainHubCopy");
                // load scene "Level1"
                SceneManager.LoadScene("MainHubCopy");
            }
        }

        if (SceneManager.GetActiveScene().name == "MainHubCopy")
        {
            // if input is "p"
            if (Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Loading Tutorial");
                // load scene "Level1"
                SceneManager.LoadScene("Tutorial");
            }
        }
        
    }
}
