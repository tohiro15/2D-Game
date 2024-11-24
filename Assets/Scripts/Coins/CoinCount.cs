using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public static CoinCount instance { get; set; }

    private int moneyNumbers;

    public TextMeshProUGUI coins;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }


    private void Start()
    {
        moneyNumbers = 0;
    }

    public void PickUpCoin()
    {
        moneyNumbers += 1;
        coins.text = $"COINS: {CoinCount.instance.moneyNumbers.ToString()}";

        SoundManager.instance.coinsChanell.PlayOneShot(SoundManager.instance.pickUpCoin);
    }
}
