using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    float timeBetween = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    IEnumerator SpawnNewEnemy()
    {
        yield return new WaitForSeconds(timeBetween);
        Vector3 spawnPos = 
            new Vector3(Random.Range(-13f, 13f), 0, transform.position.z) ;
        int rand = Random.Range(0, enemyPrefabs.Length);
        GameObject clone = Instantiate(enemyPrefabs[rand]);
        clone.transform.position = spawnPos;

        StartCoroutine(SpawnNewEnemy());
    }

   
}
