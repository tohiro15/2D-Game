using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underworld : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player.instance.health = 0;
            Player.instance.Death();
        }
    }
}
