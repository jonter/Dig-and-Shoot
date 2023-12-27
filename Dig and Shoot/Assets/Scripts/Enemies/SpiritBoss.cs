using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritBoss : EnemyBrain
{
    [SerializeField] float timeBetweenTP = 2;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(TeleportCoroutine());
    }

    IEnumerator TeleportCoroutine()
    {
        float gap = timeBetweenTP + Random.Range(0, 0.6f);
        yield return new WaitForSeconds(gap);
        while(isFrozen == true) yield return null; 
        if (enabled == false) yield break;
        float x = Random.Range(-10f, 10f);
        float distanceX = Mathf.Abs(transform.position.x - x);
        while (distanceX < 2)
        {
            x = Random.Range(-10f, 10f);
            distanceX = Mathf.Abs(transform.position.x - x);
        }
        transform.position = new Vector3(x, 0, transform.position.z);
        StartCoroutine(TeleportCoroutine());
    }

}
