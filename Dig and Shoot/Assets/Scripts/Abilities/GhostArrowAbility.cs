using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostArrowAbility : Ability
{
    float abilityDuration = 4;

    protected override void Start()
    {
        reloadTime = GameStats.GetReloadTime("ghost");
        abilityDuration = GameStats.GetGhostTime();
        if (reloadTime == 0 || reloadTime > 1000)
        {
            skillButton.gameObject.SetActive(false);
        }
        base.Start();
    }
    protected override void Activate()
    {
        if (isReloaded == false) return;
        BallistaAim ballista = FindObjectOfType<BallistaAim>();
        StartCoroutine(ballista.EnableGhostCoroutine(abilityDuration));
        Reload();
    }

}
