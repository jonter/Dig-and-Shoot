using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndWaveText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InfiniteSpawner spawner = FindObjectOfType<InfiniteSpawner>();
        int waveNum = spawner.GetWaveNum();
        GetComponent<TMP_Text>().text = $"Ты дошел до {waveNum} волны";
    }

    
}
