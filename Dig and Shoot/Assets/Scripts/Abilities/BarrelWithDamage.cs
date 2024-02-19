using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BarrelWithDamage : ExplosiveBarrel
{
    float explosionRadius = 8;
    float damage = 100;

    public void Launch(Vector3 point, float d)
    {
        damage = d;
        transform.DOMoveX(point.x, 2).SetEase(Ease.Linear);
        transform.DOMoveZ(point.z, 2).SetEase(Ease.Linear);
        transform.DOMoveY(10, 1).SetEase(Ease.OutQuad).SetLoops(2, LoopType.Yoyo);
        transform.DORotate(new Vector3(360, 0, 0), 2, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear);
        StartCoroutine(BurstWithDelay());
    }

    IEnumerator BurstWithDelay()
    {
        yield return new WaitForSeconds(2);
        MakeBoom();
        transform.DOKill();
    }


    protected override void MakeBoom()
    {
        DamageInRadius();
        base.MakeBoom();
    }

    void DamageInRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        
        for (int i = 0; i < colliders.Length; i++)
        {
            EnemyHealth enemy = colliders[i].GetComponent<EnemyHealth>();
            if (enemy) enemy.GetDamage(damage);
        }

    }


}
