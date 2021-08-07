using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBouncer : MonoBehaviour
{
    public GameObject abc;
   

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) // need to make a box collider with isTrigger
        {
            //abc.GetComponentsInParent<GameObject>;
            //Debug.Log("hit");
           //if (movement_direction == true) { movement_direction = false; }
            //else if (movement_direction == false) { movement_direction = true; }

        }
    }





    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
