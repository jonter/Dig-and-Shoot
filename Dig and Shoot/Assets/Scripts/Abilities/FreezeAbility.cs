using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAbility : Ability
{
    [SerializeField] GameObject frostVFX;
    float freezeTime = 4;

    protected override void Activate()
    {
        if (isReloaded == false) return;
        Vector3 pos = new Vector3(0, 0.2f, 25);
        Instantiate(frostVFX, pos, Quaternion.identity);
        Reload();
        StartCoroutine(FreezeCoroutine());
    }

    IEnumerator FreezeCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        EnemyBrain[] enemies = FindObjectsOfType<EnemyBrain>();
        for (int i = 0; i < enemies.Length; i++)
        {
            StartCoroutine(enemies[i].FreezeEnemyCoroutine(freezeTime));
        }
        
    }





}
