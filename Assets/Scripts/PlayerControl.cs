using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    private Collider2D attackCollider;
    private Vector2 movement;
    private float updateSpeed;
    private bool IsAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        if (attackCollider != null)
            attackCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);


        if (movement.x != 0)
        {
            animator.SetBool("FacingSide", true);
            animator.SetBool("FacingBack", false);
        }
        else if (movement.y > 0)
        {
            animator.SetBool("FacingSide", false);
            animator.SetBool("FacingBack", true);
        }
        else if (movement.y < 0)
        {
            animator.SetBool("FacingSide", false);
            animator.SetBool("FacingBack", false);
        }

        if (movement.x < 0)
        {
            // flip sprite
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement.x > 0)
        {
            // flip sprite
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("Attack"))
        {
            IsAttacking = true;
            movement.x = 0;
            movement.y = 0;
            animator.SetBool("IsAttacking", true);
        }
    }

    public void EndAttack()
    {
        animator.SetBool("IsAttacking", false);
        IsAttacking = false;
    }

    void FixedUpdate()
    {
        updateSpeed = moveSpeed;
        if (movement.x != 0 && movement.y != 0)
            updateSpeed *= 0.75f;

        if (IsAttacking)
            updateSpeed = 0f;

        rb.MovePosition(rb.position + movement * updateSpeed * Time.fixedDeltaTime);
    }
}
