using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;
    
    private float movementX;
    private bool isGrounded = true;
    private string WALK_ANIMATION = "Walk";
    private string JUMP_ANIMATION = "Jump";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private Animator anim;
    private SpriteRenderer sr;
    private Rigidbody2D mybody;     //this is only declaration. the proper method of referencing it is given below.
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        mybody = GetComponent<Rigidbody2D>();   //this is how u actually reference a compnent attatched to a game object. WE can either do this or gice a [serialaizedfield] above the declaration and then drag and drop the game object into the corresponding component.
        _transform.position = new Vector3(0f, 0f, 0f);// this is to initialize the players position into centre before the game starts
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        animatePlayer();
        playerJump();
    }

    void movePlayer()
    {
        movementX = Input.GetAxisRaw("Horizontal"); //GetAxisRaw has values {-1, 0, 1}. wheras GetAxis has values which slowly increases from -1 to 0 to 1.
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;  //this is the code for movement. time.deltatime is used to smoothen the movement. since there is movement only along the X axis, the 2nd and 3rd argument of the Vector3 is kept as 0.
        
    }

    void animatePlayer()
    {
        if(movementX > 0)   // moving right
        {
            sr.flipX = false;   //do not flip the player
            anim.SetBool(WALK_ANIMATION, true); //enable the walk animation
        }
        else if(movementX < 0)  //move left
        {
            sr.flipX = true;    //flip the player(so it will face left side)
            anim.SetBool(WALK_ANIMATION, true); 
        }
        else    //idle
        {
            anim.SetBool(WALK_ANIMATION, false);   //no walk animation for idle 
        }
    }
    
    void playerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)  //GetbuttonDown - only when when the button is pressed 'down' once. GetButtonUp - only when the pressed button is released 'up'. Getbutton - works when we press down, release and hold it.
        {
            isGrounded = false;//after jumping, value is made to false until the player collides with the ground again. this is to prevent jumping more than once in the air.
            mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);//adds forxe to the rigid body component.only in the Y direction coz we r JUMPING. thats why x in new vector2 is kept as 0;
            // anim.SetBool(JUMP_ANIMATION, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //this is to detect the collision of the player with the ground after a single jump. After collision, the value is set to true.
    { 
        if(collision.gameObject.CompareTag(GROUND_TAG)) //GROUND_TAG = "Ground", i.e, the tag given to the ground objects(images) inside the editor.
        {
            isGrounded = true;
            // anim.SetBool(JUMP_ANIMATION, false);
        
        }

        if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            GameOverManager.isGameOver = true;
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
         if(collision.CompareTag(ENEMY_TAG))
            {
                Destroy(gameObject); 
                GameOverManager.isGameOver = true;
            }
    }
}


