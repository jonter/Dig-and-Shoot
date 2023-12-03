using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.Http.Headers;

public class UpgradeParameter : MonoBehaviour
{
    Button upgradeButton;
    [SerializeField] protected TMP_Text levelText;
    [SerializeField] protected TMP_Text priceText;

    [SerializeField] protected string ID = "damage";
    [SerializeField] protected int[] prices;

    // Start is called before the first frame update
    void Start()
    {
        upgradeButton = GetComponentInChildren<Button>();
        upgradeButton.onClick.AddListener(Upgrade);

        DisplayLevel();
    }

    protected virtual void DisplayLevel()
    {
        int level = PlayerPrefs.GetInt(ID);
        if(level >= prices.Length)
        {
            priceText.text = "-----";
            levelText.text = "Ур. Макс";
        }
        else
        {
            priceText.text = "" + prices[level];
            levelText.text = "Уровень: " + (level + 1);
        }
        
    }

    void Upgrade()
    {
        int level = PlayerPrefs.GetInt(ID);
        if (level >= prices.Length) return;
        int price = prices[level];
        MenuCoins mc = FindObjectOfType<MenuCoins>();
        bool isBought = mc.SpendCoins(price);
        if (isBought == false) return;

        PlayerPrefs.SetInt(ID, level + 1);
        DisplayLevel();
    }

    
}
