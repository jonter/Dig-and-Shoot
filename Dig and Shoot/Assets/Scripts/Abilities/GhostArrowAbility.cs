using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostArrowAbility : Ability
{
    float abilityDuration = 4;

    protected override void Activate()
    {
        if (isReloaded == false) return;
        BallistaAim ballista = FindObjectOfType<BallistaAim>();
        StartCoroutine(ballista.EnableGhostCoroutine(abilityDuration));
        Reload();
    }

}
