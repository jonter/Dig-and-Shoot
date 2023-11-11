using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShootAbility : Ability
{


    protected override void Activate()
    {
        if (isReloaded == false) return;
        BallistaAim ballista = FindObjectOfType<BallistaAim>();
        StartCoroutine(ballista.IncreaseFireRateCoroutine(5));
        Reload();

    }

}
