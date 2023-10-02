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

        Destroy(gameObject, 2);
    }
}
