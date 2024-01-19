using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    int coins = 0;
    TMP_Text moneyText;
    bool isGameOver = false;

    public int GetCoins()
    {
        return coins;
    }

    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<TMP_Text>();
        moneyText.text = "" + coins;
        FindObjectOfType<EnemySpawner>().OnWin += GameOver;
        FindObjectOfType<BaseHealth>().OnDeath += GameOver;
    }

    void GameOver()
    {
        isGameOver = true;
    }

    public void AddCoins(int add)
    {
        if (isGameOver == true) return;
        coins += add;
        // добавить звуковой эффект (или даже небольшую анимацию)
        moneyText.text = "" + coins;
    }

    
}
