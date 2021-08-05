using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed;
    public Rigidbody2D theRB;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator anim;
    private SpriteRenderer theSR;

    public int PlayerHealth; 

    



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();

        PlayerHealth = 5; 


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LAVA"))
        {
            PlayerHealth--;
        }

        if (collision.gameObject.CompareTag("POISON"))
        {
            PlayerHealth--;
        }


        if (collision.gameObject.CompareTag("HEART"))
        {
            collision.gameObject.SetActive(false);
            PlayerHealth++;
        }

        if (collision.gameObject.CompareTag("HEART"))
        {
            collision.gameObject.SetActive(false);
            PlayerHealth++;
        }




    }

   void playerLoseHealth()
    {
        PlayerHealth--;
        // some algorithm that updates ui.
    }

    void playerGainHealth()
    {
        PlayerHealth++;
        // Update UI
    }


    void FixedUpdate()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(movespeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
            else
            {
                if (canDoubleJump)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }

        if (theRB.velocity.x < 0)
        {
            theSR.flipX = true;
        }
        else if (theRB.velocity.x > 0)
        {
            theSR.flipX = false;
        }



        




        Debug.Log(PlayerHealth);





        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

    }
}
