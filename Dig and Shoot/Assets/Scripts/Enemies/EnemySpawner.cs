using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EnemySpawner : MonoBehaviour
{
    public event Action OnWin;
    [SerializeField] TMP_Text waveText;
    [SerializeField] Wave[] waves;
    [SerializeField] float timeBetween = 7;

    int waveCount;
    int currentWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        waveText.text = "";
        waveCount = waves.Length;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(3);

        for (int i = 0; i < waves.Length; i++)
        {
            currentWave++;
            waveText.text = $"Волна: {currentWave}/{waveCount}";

            yield return StartCoroutine(waves[i].SpawnAllWave(transform.position));
            yield return new WaitForSeconds(timeBetween);
        }

        StartCoroutine(CheckEnemies());
    }

    IEnumerator CheckEnemies()
    {
        yield return new WaitForSeconds(1);
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        if(enemies.Length > 0)
        {
            StartCoroutine(CheckEnemies());
        }
        else
        {
            waveText.text = "Победа";
            OnWin();
        }
        

    }

   

   
}
