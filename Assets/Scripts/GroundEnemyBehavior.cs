using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyBehaviour : MonoBehaviour
{
    public bool movement_direction;
    // true = left , false = right 

    public int snakeHP;
    public Rigidbody2D snake; 

   





    void Start()
    {
        movement_direction = true;
        snakeHP = 1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) // need to make a box collider with isTrigger
        {
            //Debug.Log("hit");
            if (movement_direction == true) { movement_direction = false; }
            else if (movement_direction == false) { movement_direction = true; }

        }
        if (collision.gameObject.CompareTag("Dagger")) 
        {
            snakeHP--;
            //Debug.Log("snake -1 hp");
        }
    }

     void FixedUpdate()
    {
        if (movement_direction == true) { this.transform.Translate(this.transform.right / 30) ; }
        else if (movement_direction == false) { this.transform.Translate(-this.transform.right / 30) ;  }
    }



    // Update is called once per frame
    void Update()
    {
        if (snakeHP <= 0) { this.gameObject.SetActive(false); }
        

    }
}
