using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    public SpriteRenderer theSR;

    private bool movingRight;
    private Rigidbody2D theRB;

    public float moveTime, waitTime;
    private float moveCount, waitCount;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;

            if (movingRight)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y); //frog speed

                theSR.flipX = true; //flips frog to face correct direction

                if (transform.position.x > rightPoint.position.x) //frog moving to the right
                {
                    movingRight = false;
                }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y); //frog moing to the left

                theSR.flipX = false;

                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }

            if(moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }
            anim.SetBool("isMoving", true);
        }
        else if(waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if(waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * .75f, waitTime * .75f);
            }
            anim.SetBool("isMoving", false);
        }
    }
}
