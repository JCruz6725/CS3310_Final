using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public PlayerController p;
    int UI_HP;
    bool[] act = new bool[5];
    //public ima




    // Start is called before the first frame update
    void Start()
    {
        UI_HP = p.PlayerHealth;    
    }

    void FixedUpdate()
    {
        if (p.PlayerHealth >= 5)
        {

        }
        else if (p.PlayerHealth >= 4)
        {

        }
        else if (p.PlayerHealth >= 3)
        {

        }

        else if (p.PlayerHealth >= 2)
        {

        }
        else if (p.PlayerHealth >= 1)
        {

        }
        else if (p.PlayerHealth >= 0)
        {

        }





    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
