using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehavior : MonoBehaviour
{
    public bool movement_direction;
    // true = left , false = right 

    public float speed; 

    public int snakeHP;
    public Rigidbody2D snake; 



    //public Rigidbody2D snake;
    //snake.GetComponentInParent<Rigidbody2D>;


    // Start is called before the first frame update





    void Start()
    {
        
        movement_direction = true;
        snakeHP = 1;
        speed = 1f;
    }

    void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            
            if (movement_direction == true) { movement_direction = false; }
            else if (movement_direction == false) { movement_direction = true; }

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("!!!!!!!!!!!!!!");

        }



    }


    // Update is called once per frame
    void Update()
    {
        //if (movement_direction == true) { snake.velocity(10, 0); }
        //else if (movement_direction == false) { }

    }
}
