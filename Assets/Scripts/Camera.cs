using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // get the x and y position of the player
        float x = player.position.x;
        float y = player.position.y;

        // set the camera position to the player position
        transform.position = new Vector3(x, y, transform.position.z);

    }
}
