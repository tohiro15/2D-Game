using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class CoinsPickUp : MonoBehaviour
{

    public void PickUpCoin()
    {
        CoinCount.instance.moneyNumbers += 1;
        CoinCount.instance.coins.text = $"COINS: {CoinCount.instance.moneyNumbers.ToString()}";

        SoundManager.instance.coinsChanell.PlayOneShot(SoundManager.instance.pickUpCoin);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PickUpCoin();
            Destroy(gameObject);
        }
    }
}
