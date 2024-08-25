using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance { get; set; }

    public int maxHealth = 3;
    public int health;

    public GameObject[] hearts;

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
        health = 3;
    }

    public void TakeDamage()
    {
        health -= damageCount;

        hearts[health].SetActive(false);

        if(health <= 0)
        {
            gameObject.GetComponent<PlayerController>().enabled = false;

            UIManager.instance.Menus.SetActive(true);
            UIManager.instance.Panels.SetActive(false);
        }
    }
}
