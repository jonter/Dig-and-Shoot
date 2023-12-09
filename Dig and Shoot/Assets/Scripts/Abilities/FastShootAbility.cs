using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShootAbility : Ability
{
    float duration = 3;
    protected override void Start()
    {
        reloadTime = GameStats.GetReloadTime("fastshootability");
        duration = GameStats.GetFastShootTime();
        if(reloadTime == 0 || reloadTime > 1000)
        {
            skillButton.gameObject.SetActive(false);
        }
        base.Start();
    }

    protected override void Activate()
    {
        if (isReloaded == false) return;
        BallistaAim ballista = FindObjectOfType<BallistaAim>();
        StartCoroutine(ballista.IncreaseFireRateCoroutine(duration));
        Reload();

    }

}
