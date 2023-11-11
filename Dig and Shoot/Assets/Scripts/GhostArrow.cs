using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostArrow : Arrow
{
    public override void Launch()
    {
        base.Launch();
        damage *= 1.5f;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (isLaunched == false) return;

        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy)
        {
            enemy.GetDamage(damage);
        }
        
    }

}
