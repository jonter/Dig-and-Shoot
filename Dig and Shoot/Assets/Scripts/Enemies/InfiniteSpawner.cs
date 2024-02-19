using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSpawner : EnemySpawner
{
    [SerializeField] Wave[] easyWaves;
    [SerializeField] Wave[] normalWaves;
    [SerializeField] Wave[] hardWaves;
    [SerializeField] Wave[] expertWaves;

    float hpMult = 5;
    float coinsMult = 3;

    public int GetWaveNum()
    {
        return currentWave;
    }

    protected override void Start()
    {
        currentWave = 60;
        hpMult = 10;
        waveText.text = "";
        StartCoroutine(SpawnCoroutine());
    }


    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(timeBetween);
        currentWave++;
        waveText.text = "Волна: " + currentWave;
        Wave w = SelectWave();
        
        yield return StartCoroutine(w.SpawnAllWave(transform.position, hpMult, coinsMult));
        hpMult += 0.1f;
        coinsMult += 0.1f;

        StartCoroutine(SpawnCoroutine());
    }


    Wave SelectWave()
    {
        Wave w;
        Wave[] waves;
        if(currentWave < 15) waves = easyWaves;
        else if(currentWave < 35) waves = normalWaves;
        else if(currentWave < 60) waves = hardWaves;
        else waves = expertWaves;

        int r = Random.Range(0, waves.Length);
        w = waves[r];

        return w;
    }



}
