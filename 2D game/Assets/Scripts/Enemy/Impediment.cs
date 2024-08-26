using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impediment : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Player.instance.TakeDamage();
        }

    }
}
