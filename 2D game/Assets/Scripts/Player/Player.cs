using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance { get; set; }

    public GameObject[] hearts;
    public int maxHealth = 3;
    public int health;

    public Rigidbody2D rb;
    public float damageForce = 6f;
    public int damageCount = 1;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 3;
    }

    public void TakeDamage()
    {
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
        if (health <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<PlayerController>().enabled = false;
            GetComponent<Death>().enabled = true;

            SoundManager.instance.backgroundChanell.Stop();
            SoundManager.instance.playerChanell.PlayOneShot(SoundManager.instance.deathSound);
        }
    }    
}
