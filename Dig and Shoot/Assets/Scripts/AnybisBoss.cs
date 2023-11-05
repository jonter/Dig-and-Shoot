using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnybisBoss : EnemyBrain
{
    [SerializeField] GameObject enemyPrefab;

    bool isAction = false;
    [SerializeField] float skillReload = 10;
    [SerializeField] float summonHpMult = 1;

    protected override void Start()
    {
        float rand = Random.Range(-5f, 5f);
        transform.position = new Vector3(rand, 0, transform.position.z);

        base.Start();
        StartCoroutine(SummonCoroutine());
    }

    IEnumerator SummonCoroutine()
    {
        yield return new WaitForSeconds(skillReload);

        anim.SetTrigger("skill");
        rb.velocity = new Vector3();
        isAction = true;
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(SpawnSkeleton());
            yield return new WaitForSeconds(0.12f);
        }
        yield return new WaitForSeconds(0.8f);
        isAction = false;
        StartCoroutine(SummonCoroutine());
    }


    IEnumerator SpawnSkeleton()
    {
        float rand = Random.Range(-3f, 3f);
        Vector3 spawnPos = transform.position + new Vector3(rand, -2.5f, 3);
        Quaternion rot = Quaternion.Euler(0, 180, 0);
        GameObject clone = Instantiate(enemyPrefab, spawnPos, rot);
        clone.GetComponent<EnemyBrain>().enabled = false;
        clone.GetComponent<EnemyHealth>().IncreaseHP(summonHpMult);
        clone.transform.DOMoveY(0, 0.5f);
        Vector3 rot2 = new Vector3(0, 360, 0);
        clone.transform.DORotate(rot2, 0.5f, RotateMode.WorldAxisAdd);
        yield return new WaitForSeconds(0.5f);
        clone.GetComponent<EnemyBrain>().enabled = true;
    }

    protected override void Update()
    {
        if (isAction == true) return;
        base.Update();
    }


}
