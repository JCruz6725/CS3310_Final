using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerS : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.SetActive(false);
    }
}
