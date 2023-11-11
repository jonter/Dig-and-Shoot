using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Projectile : MonoBehaviour
{
    public void Throw(BaseHealth target, float damage)
    {
        transform.DOMoveZ(target.transform.position.z, 2).SetEase(Ease.Linear);
        transform.DOMoveY(10, 1).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutQuad);
        Vector3 rot = Random.insideUnitSphere * 1000;
        transform.DORotate(rot, 2, RotateMode.WorldAxisAdd).SetEase(Ease.Linear);

        StartCoroutine(BurstCoroutine(target, damage));
    }

    IEnumerator BurstCoroutine(BaseHealth target, float damage)
    {
        yield return new WaitForSeconds(2);
        ParticleSystem burstVFX = GetComponentInChildren<ParticleSystem>();
        burstVFX.transform.parent = null;
        burstVFX.Play();
        target.GetDamage(damage);
        Destroy(gameObject);
    }

}
