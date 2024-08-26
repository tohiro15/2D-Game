using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; set; }

    public GameObject Panels;
    public GameObject Menus;
    public Image BackgroundDeath;
    public Color ImageColor;
    public float SpeedDeath = 5f;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        ImageColor = BackgroundDeath.color;
        ImageColor.a = 0;
    }

    public void Death()
    {
        Menus.SetActive(true);
        Panels.SetActive(false);


        if (ImageColor.a != 255)
        {
            ImageColor.a += SpeedDeath * Time.deltaTime;
            BackgroundDeath.color = ImageColor;
        }
    }
}
