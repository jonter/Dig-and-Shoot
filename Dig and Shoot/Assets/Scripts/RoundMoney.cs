using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundMoney : MonoBehaviour
{

    public void DisplayMoney(int coins)
    {
        TMP_Text mytext = GetComponent<TMP_Text>();
        mytext.text = "Монет за раунд: " + coins;
    }
    
}
