using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave")]
public class Wave : ScriptableObject
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float timeBetween = 1;
    [SerializeField] float hpMult = 1;
    [SerializeField] float coinsMult = 1;

    public IEnumerator SpawnAllWave(Vector3 spawnerPos)
    {
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            float randomX = Random.Range(-12f, 12f);
            Vector3 pos = spawnerPos + new Vector3(randomX, 0, 0);
            Quaternion rot = Quaternion.Euler(0, 180, 0);
            GameObject clone = Instantiate(enemyPrefabs[i], pos, rot);
            clone.GetComponent<EnemyHealth>().IncreaseHP(hpMult);
            clone.GetComponent<EnemyHealth>().IncreaseCoins(coinsMult);
            
            yield return new WaitForSeconds(timeBetween);
        }

    }

    
}
