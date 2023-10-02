using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistEnemyBrain : EnemyBrain
{
    [SerializeField] GameObject crystal;

    public override void Attack()
    {
        if (target == null) return;

        GameObject clone = Instantiate(crystal, crystal.transform.position,
            crystal.transform.rotation);
        crystal.SetActive(false);
        clone.GetComponent<Projectile>().Throw(target, damage);
    }


}
