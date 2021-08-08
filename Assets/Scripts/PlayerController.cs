using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;

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



    public GameObject[] PlayerHealthUI = new GameObject[5];
    public GameObject gameOverText;
    public Rigidbody2D Dagger_Projectile;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Poison"))
        {
            playerLoseHealth();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerLoseHealth();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Heart"))
        {
            playerGainHealth();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Lava"))
        {
            playerLoseHealth();
        }
        if (collision.gameObject.CompareTag("Killbox"))
        {
            InstaKill();

        }




        }




    void InstaKill()
    {

        for (int i = 0; i < 5; i++)
        {
            if (PlayerHealthUI[i].gameObject.activeSelf)
            {
                PlayerHealthUI[i].gameObject.SetActive(false);
                if (i == 4) { gameOver(); this.gameObject.SetActive(false); }
                
            }
        }
    }




    void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
        
    }

    void playerLoseHealth()
    {

        for (int i = 0; i < 5; i++)
        {
            if (PlayerHealthUI[i].gameObject.activeSelf)
            {
                PlayerHealthUI[i].gameObject.SetActive(false);
                if (i == 4) { gameOver(); this.gameObject.SetActive(false); }
                break;
            }
        }
    }

    void playerGainHealth()
    {

        for (int i = 4; i > -1; i--)
        {
            if (!PlayerHealthUI[i].gameObject.activeSelf)
            {
                PlayerHealthUI[i].gameObject.SetActive(true);
                break;
            }
        }
    }


    void throwDagger ( )
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            float x, y, z;

            y = this.gameObject.transform.position.y;
            z = this.gameObject.transform.position.z;



            
            
            
            if (theSR.flipX == false) {
                x = this.gameObject.transform.position.x + 1f;
                Vector3 player_position = new Vector3(x, y, z);
                Rigidbody2D projectile = Instantiate(Dagger_Projectile, player_position, Quaternion.identity);
                projectile.velocity = transform.right * 15f;
            }
           
            else
            {
                x = this.gameObject.transform.position.x - 1f;
                Vector3 player_position = new Vector3(x, y, z);
                Rigidbody2D projectile = Instantiate(Dagger_Projectile, player_position, Quaternion.identity);
                projectile.gameObject.transform.Rotate(new Vector3 (0,0,180));
                projectile.velocity = -transform.right * 15f;
            }

            

        }



    }




    // Update is called once per frame
    void Update()
    {
        throwDagger();


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

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);

    }
}
