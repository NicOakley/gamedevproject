using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;
    private float updateSpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        if (movement.sqrMagnitude > 0)
            animator.SetFloat("Speed", 1);
        
        if(movement.x < 0){
            // flip sprite
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(movement.x > 0){
            // flip sprite
            transform.localScale = new Vector3(1, 1, 1);
        }

        
        

    } 

    void FixedUpdate()
    {
        updateSpeed = moveSpeed;
        if (movement.x != 0 && movement.y != 0)
            updateSpeed *= 0.75f;

        rb.MovePosition(rb.position + movement * updateSpeed * Time.fixedDeltaTime);



        


    }

}
