using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public static CoinCount instance { get; set; }

    public int moneyNumbers;
    public int currentMoneyNumbers;

    public TextMeshProUGUI coins;
    public Color color;

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
        coins = GetComponent<TextMeshProUGUI>();
    }

    public void DeathUI()
    {
        color = coins.color;
        color.a = 255;
        coins.color = color;
    }
}
