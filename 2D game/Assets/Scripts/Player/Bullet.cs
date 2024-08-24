using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float disappearanceTime = 2f;
    public float force = 100f;

    Rigidbody2D rb;

    public PlayerController isRotated;

    private void Start()
    {
        isRotated = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();

        Shoot();

        Destroy(gameObject, disappearanceTime);
    }

    public void Shoot()
    {
        if(isRotated.isLeft == false)
            rb.AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
        else
            rb.AddForce(new Vector2(-force, 0), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.name == "Enemy")
        {
            Destroy(enemy.gameObject);
        }
    }
}
