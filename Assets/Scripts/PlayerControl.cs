using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sr;
    [SerializeField] private Collider2D sideCollider;
    [SerializeField] private Collider2D backCollider;
    [SerializeField] private Collider2D frontCollider;
    private Vector2 movement;
    private float updateSpeed;
    private bool IsAttacking = false;
    private bool facingSide;
    private bool facingBack;
    private bool damageable = true;

    // Start is called before the first frame update
    void Start()
    {
        //Ensure the attack colliders are disabled if they exist
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
        //Get directional input from player
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Tell the animator which directions the player is moving
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        //If the player is moving left or right
        if (movement.x != 0)
        {
            //Set that the player is moving to the side and not the back
            facingSide = true;
            facingBack = false;
            //Update the animator
            animator.SetBool("FacingSide", true);
            animator.SetBool("FacingBack", false);
        }
        //If the player is moving up but not left or right
        else if (movement.y > 0)
        {
            //Set that the player is moving to the back and not the side
            facingSide = false;
            facingBack = true;
            //Update the animator
            animator.SetBool("FacingSide", false);
            animator.SetBool("FacingBack", true);
        }
        //If the player is moving down but not left or right
        else if (movement.y < 0)
        {
            //Set that the player is not moving back or to the side
            facingSide = false;
            facingBack = false;
            //Update the animator
            animator.SetBool("FacingSide", false);
            animator.SetBool("FacingBack", false);
        }

        //If the player is moving left, face the sprite left
        if (movement.x < 0)
        {
            sr.flipX = true;
        }
        //If the player is moving right, face the sprite right
        else if (movement.x > 0)
        {
            sr.flipX = false;
        }

        //If the player presses an attack button
        if (Input.GetButtonDown("Attack"))
        {
            //Set that we are attacking, then update animator
            IsAttacking = true;
            animator.SetBool("IsAttacking", true);
        }
    }

    //Called with an Animation Event on the last frame of attack animations,
    //set that the player is no longer attacking and updates the animator
    public void EndAttack()
    {
        IsAttacking = false;
        animator.SetBool("IsAttacking", false);
    }

    //Called with an Animation Event to enable one of the player's attack
    //colliders on frames that should do damage. Attack collider chosen
    //depends on which direction the player is facing
    public void EnableAtkCollider()
    {
        if (facingSide)
            sideCollider.enabled = true;
        else if (facingBack)
            backCollider.enabled = true;
        else
            frontCollider.enabled = true;
    }

    //Called with an Animation Event after frames that should deal damage
    //to disable the player's attack colliders 
    public void DisableAtkCollider()
    {
        sideCollider.enabled = false;
        backCollider.enabled = false;
        frontCollider.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {
            float damageTaken = collision.gameObject.GetComponent<Enemy>().atkStat;
            gameObject.GetComponent<Player>().HealthBar.health -= damageTaken;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {
            if (damageable)
            {
                StartCoroutine(WaitForSeconds());
                float damageTaken = collision.gameObject.GetComponent<Enemy>().atkStat;
                gameObject.GetComponent<Player>().HealthBar.health -= damageTaken;
            }
        }
    }

    IEnumerator WaitForSeconds()
    {
        damageable = false;
        yield return new WaitForSecondsRealtime(0.5f);
        damageable = true;
    }

    //Called once every physics update
    void FixedUpdate()
    {
        //If the player is moving diagonally set speed to 75%
        updateSpeed = moveSpeed;
        if (movement.x != 0 && movement.y != 0)
            updateSpeed *= 0.75f;

        //If the player is attacking set speed to 0
        if (IsAttacking)
            updateSpeed = 0f;

        //Apply movements to the player's rigidbody
        rb.MovePosition(rb.position + movement * updateSpeed * Time.fixedDeltaTime);
    }
}
