using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D col;
    public Sword sword;
    public PlayerAttack playerAttack;
   

    //private bool isClimbing;

    //LADDER
    
   
  
    [SerializeField] float climbSpeed = 3f;

   
    public bool isClimbing;


    private float dirX = 0f;
    private float dirY = 0f;
    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] public float slowSpeed = 3f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    public LayerMask whatIsLadder;
    public float distance;

    private enum MovementState {idle, running, jumping, falling, climb, attack  }

    //Armed animations
    public RuntimeAnimatorController armedController;
    public RuntimeAnimatorController unarmedController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        //running
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //climbing

        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
        if (hitinfo.collider != null) {
            if (Input.GetButtonDown("Vertical"))
            {
                isClimbing = true;
                Debug.Log("climbing");
            }
            else {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
                    isClimbing = false;
                }
            }
                
        }
        if (isClimbing == true)
        {
            dirY = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(0f, dirY * climbSpeed);
            rb.gravityScale = 0;
        }
        else { 
            rb.gravityScale = 5;
        }
            
        


        
        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }

        if (sword.hasSword == true) {
            anim.runtimeAnimatorController = armedController as RuntimeAnimatorController;
        }
        else
            anim.runtimeAnimatorController = unarmedController as RuntimeAnimatorController;

        UpdateAnim();
       
    }

    private void UpdateAnim() {

        MovementState state;
        //running anim
        if (dirX > 0f) //right
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f) //left
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        //jumping
        if (rb.velocity.y > .1f) {
            state = MovementState.jumping;
        }
        //falling
        else if (rb.velocity.y < -.1f) {
            state = MovementState.falling;
        }

        //climbing
        if (isClimbing)
        {
            state = MovementState.climb;
        }

        if (playerAttack.attacking == true) {
            state = MovementState.attack;
        }
     
        //setanim
        anim.SetInteger("state", (int)state);


    }



    
    private bool isGrounded() {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround );
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SlowTile"))
        {
            moveSpeed = slowSpeed;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SlowTile"))
        {
            moveSpeed = 7f;
        }
    }


}
