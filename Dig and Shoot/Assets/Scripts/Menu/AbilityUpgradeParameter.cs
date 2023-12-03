using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUpgradeParameter : UpgradeParameter
{
    protected override void DisplayLevel()
    {
        int level = PlayerPrefs.GetInt(ID);
        if (level >= prices.Length)
        {
            priceText.text = "-----";
            levelText.text = "Ур. Макс";
        }
        else if(level > 0)
        {
            priceText.text = "" + prices[level];
            levelText.text = "Уровень: " + level;
        }
        else
        {
            priceText.text = "" + prices[level];
            levelText.text = "Не открыто";
        }
    }

}
