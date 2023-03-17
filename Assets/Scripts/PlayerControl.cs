using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    [SerializeField] private Collider2D sideCollider;
    [SerializeField] private Collider2D backCollider;
    [SerializeField] private Collider2D frontCollider;
    private Vector2 movement;
    private float updateSpeed;
    private bool IsAttacking = false;
    private bool facingSide;
    private bool facingBack;

    // Start is called before the first frame update
    void Start()
    {
        if (sideCollider != null)
            sideCollider.enabled = false;

        if (backCollider != null)
            backCollider.enabled = false;

        if (frontCollider != null)
            frontCollider.enabled = false;
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
            facingSide = true;
            facingBack = false;
            animator.SetBool("FacingSide", true);
            animator.SetBool("FacingBack", false);
        }
        else if (movement.y > 0)
        {
            facingSide = false;
            facingBack = true;
            animator.SetBool("FacingSide", false);
            animator.SetBool("FacingBack", true);
        }
        else if (movement.y < 0)
        {
            facingSide = false;
            facingBack = false;
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
            animator.SetBool("IsAttacking", true);
        }
    }

    public void EndAttack()
    {
        animator.SetBool("IsAttacking", false);
        IsAttacking = false;
    }

    public void EnableAtkCollider()
    {
        if (facingSide)
            sideCollider.enabled = true;
        else if (facingBack)
            backCollider.enabled = true;
        else
            frontCollider.enabled = true;
    }

    public void DisableAtkCollider()
    {
        sideCollider.enabled = false;
        backCollider.enabled = false;
        frontCollider.enabled = false;
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
