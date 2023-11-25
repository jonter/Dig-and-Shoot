using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MenuCoins : MonoBehaviour
{
    TMP_Text coinsText;
    // Start is called before the first frame update
    void Start()
    {
        int coins = PlayerPrefs.GetInt("coins");
        coinsText = GetComponentInChildren<TMP_Text>();
        coinsText.text = "" + coins;
    }

    public void AddCoins(int add)
    {
        int coins = PlayerPrefs.GetInt("coins");
        coins += add;
        PlayerPrefs.SetInt("coins", coins);
        // можно добавить прикольный звук
        coinsText.transform.DOLocalMoveY(coinsText.transform.localPosition.y + 10, 0.1f)
            .SetLoops(2, LoopType.Yoyo);
        coinsText.text = "" + coins;
    }

    public bool SpendCoins(int price)
    {
        int coins = PlayerPrefs.GetInt("coins");
        if (coins < price) return false;

        coins -= price;
        PlayerPrefs.SetInt("coins", coins);
        // можно добавить прикольный звук
        coinsText.transform.DOLocalMoveY(coinsText.transform.localPosition.y + 10, 0.1f)
            .SetLoops(2, LoopType.Yoyo);
        coinsText.text = "" + coins;
        return true;
    }


}
