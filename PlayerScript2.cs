using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript2 : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    public float moveSpeed;
    private bool facingRight;
    [SerializeField]
    private Transform[] groundPoints; //creates an array of "points" (actually game objects) to collide with the ground
    [SerializeField]
    private float groundRadius;//creates the size of the collider
    [SerializeField]
    private LayerMask whatIsGround;//defines what is ground
    private bool isGrounded;//can be set to true or false based on our position
    private bool jump;//can be set to true or false when we press the space key
    [SerializeField]
    public float jumpForce;//allows us to determine the magnitude of the jump
    public bool Alive;
    public GameObject reset;
    private Slider healthBar;
    public float health = 6f;
    private float healthBurn = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Alive = true;
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();      //a variable to control the Player's body
        myAnimator = GetComponent<Animator>();      //a variable to control the Player's Animator controller
        reset.SetActive(false);
        healthBar = GameObject.Find("health slider").GetComponent<Slider>();
        healthBar.minValue = 0f;
        healthBar.maxValue = health;
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // a variable that stores the value of our horizontal movement
                                                        //Debug.Log(horizontal);
        if (Alive)
        {
            PlayerMovement(horizontal);
            Flip(horizontal);
            HandleInput();
        }

        isGrounded = IsGrounded();
    }

    //Function Definitions

    //a function that controls player on the x axis
    private void PlayerMovement(float horizontal)
    {
        if (isGrounded && jump)
        {
            isGrounded = false;
            jump = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));

        }
        myRigidbody.velocity = new Vector2(horizontal * moveSpeed, myRigidbody.velocity.y); //adds velocity to the player's body on the x axis
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
        // myAnimator.SetBool("jumping", !isGrounded);
    }

    private void Flip(float horizontal)
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight; //resets the bool to the opposite value
            Vector2 theScale = transform.localScale;  //creating a vector 2 and storing the local scale values
            theScale.x *= -1;        //
            transform.localScale = theScale;
        }

    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            myAnimator.SetBool("jumping", true);
            // Debug.Log ("I'm jumping");
        }
    }
    //function to test for collisions between the array of groundpoints and the Ground LayerMask
    private bool IsGrounded()
    {
        if (myRigidbody.velocity.y <= 0)
        {
            //if player is not moving vertically, test each of Player's groundPoints for collision with Ground
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; 1 < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject) //if any of the colliders in the array of groundPoints comes into contact with another gameobject, return true.
                    {
                        return true;

                    }
                }
            }
        }
        return false; //if the player is not moving along the y axis, return false.
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "ground")
        {
            myAnimator.SetBool("jumping", false);
        }
        if (target.gameObject.tag == "deadly")
        {
            ImDead();
        }
        if (target.gameObject.tag == "damage")
        {
            UpdateHealth();
        }

        void UpdateHealth()
        {
            if (health > 0)
            {
                health -= healthBurn; // health = health - healthBurn
                healthBar.value = health;
            }
            if (health <= 0)
            {
                ImDead();
            }
        }

    }
    
    public void ImDead()
    {
        myAnimator.SetBool("dead", true);
        reset.SetActive(true);
        Alive = false;
        healthBar.value = 0;
        GameObject.Find("Player (1)").GetComponent<PlayerScript22>().isAlive = false;
        GameObject.Find("Player (1)").GetComponent<PlayerScript22>().myAnimator.SetBool("dead", true);
    }
}