using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

    public float moveSpeed;
    private HealthBar HealthBar;
    public float health = 100f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Transform target;
    private Transform bossPos;
    public GameObject levelExit;
    public GameObject projectile;
    [SerializeField] private float knockWeakness = 0f;
    [SerializeField] private Animator animator;
    private float damageTaken;

    float timer = 0;
    bool timerReached = false;

    int shot = 0;

    bool stage1 = false;
    bool stage2 = false;
    bool stage3 = false;



    public static string[] actions = {"chasePlayer", "moveToCenter", "standingCenter", "none"};
    public static string action = "chasePlayer";

    // Start is called before the first frame update
    void Start()
    {

        HealthBar = GetComponentInChildren<HealthBar>();
        HealthBar.MAX_HEALTH = health;
        HealthBar.health = health;

        bossPos = GetComponent<Transform>();

        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!timerReached) timer += Time.deltaTime;

        if (!timerReached && timer > 1f) {
            timerReached = true;
        }


        

        
        
    }

    void FixedUpdate() {

         // if x velocity is greater than 0 (moving right)
        if (rb.velocity.x >= 0) {
            // flip sprite to face right
            sr.flipX = false;
            if (animator != null)
                animator.SetBool("IsMoving", true);
        }
        // if x velocity is less than 0 (moving left)
        else if(rb.velocity.x < 0) {
            // flip sprite to face left
            sr.flipX = true;
            if (animator != null)
                animator.SetBool("IsMoving", true);
        }
        else {
            if (animator != null)
                animator.SetBool("IsMoving", false);
        }

        if (action == "none"){
            return;
        }

        
        // if current attack is chase 
        if(action == "chasePlayer"){
            // move towards the player
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            rb.velocity = direction * moveSpeed;
        }

        if (action == "moveToCenter") {
            // move towards the center
            Vector2 direction = new Vector2(-5.282f, -1.18f) - rb.position;
            direction.Normalize();
            rb.velocity = direction * (moveSpeed+1);
        }

        if (action == "standingCenter") {
            Debug.Log("standingCenter");
            // stop moving
            rb.velocity = Vector2.zero;

            timer += Time.deltaTime;

            if (timer > .7f) {
                Debug.Log("timerReached");
                Instantiate(projectile, new Vector3(bossPos.position.x, bossPos.position.y, -5), Quaternion.identity);
                timer = 0;
                shot++;

                if(shot >= 20){
                    shot = 0;
                    action = "chasePlayer";
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "centerTrigger" && action == "moveToCenter") {
            Debug.Log("Boss is at center");
            action = "standingCenter";
        }

        if (collision.gameObject.tag == "Player") {
            damageTaken = collision.gameObject.GetComponent<Player>().atkStat;
            HealthBar.health = HealthBar.health - damageTaken;

            Vector2 direction = (transform.position - collision.transform.position).normalized;
            Vector2 knockback = direction * knockWeakness;
            rb.AddForce(knockback, ForceMode2D.Force);
        }

        if (HealthBar.health <= 0) {
            levelExit.SetActive(true);
            Destroy(gameObject);
        }

        if( stage1 == false && HealthBar.health <= HealthBar.MAX_HEALTH/2 ){
            stage1 = true;
            action = "moveToCenter";
        }

        if( stage2 == false && HealthBar.health <= HealthBar.MAX_HEALTH/4 ){
            stage2 = true;
            action = "moveToCenter";
        }

        if( stage3 == false && HealthBar.health <= HealthBar.MAX_HEALTH/1.1 ){
            stage3 = true;
            action = "moveToCenter";
        }
    }





}
