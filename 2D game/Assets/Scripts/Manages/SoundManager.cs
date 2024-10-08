using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; set; }


    [Header("Player")]

    public AudioSource playerChanell;
    public AudioClip jumpSound;
    public AudioClip damageSound;
    public AudioClip deathSound;

    [Header("Background")]

    public AudioSource backgroundChanell;
    public AudioClip backroundMusic;

    [Header("Coins")]

    public AudioSource coinsChanell;
    public AudioClip pickUpCoin;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }
}
