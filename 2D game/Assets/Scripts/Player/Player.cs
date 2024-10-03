using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] hearts;
    public int maxHealth { get; private set; } = 3;
    public int health;

    private Rigidbody2D rb;
    private Animator animator;
    public float damageForce { get; private set; } = 6f;
    public int damageCount { get; private set; } = 1;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage();
        }

        if (collision.CompareTag("Underworld"))
        {
            Death();
        }
    }

    public void TakeDamage()
    {
        animator.SetTrigger("damage");
        health -= damageCount;

        if (health <= 0)
        {
            Death();
        }
        else
        {
            hearts[health].SetActive(false);

            SoundManager.instance.playerChanell.PlayOneShot(SoundManager.instance.damageSound);

            rb.velocity = new Vector2(0, 0) * Time.deltaTime;
            rb.AddForce(new Vector2(-1, damageForce), ForceMode2D.Impulse);
        }
    }

    public void Death()
    {
        health = 0;

        GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<Death>().enabled = true;

        SoundManager.instance.backgroundChanell.Stop();
        SoundManager.instance.playerChanell.PlayOneShot(SoundManager.instance.deathSound);
    }
}
