using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    int coins = 0;
    TMP_Text moneyText;

    public int GetCoins()
    {
        return coins;
    }

    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<TMP_Text>();
        moneyText.text = "" + coins;
    }

    public void AddCoins(int add)
    {
        coins += add;
        // добавить звуковой эффект (или даже небольшую анимацию)
        moneyText.text = "" + coins;
    }

    
}
