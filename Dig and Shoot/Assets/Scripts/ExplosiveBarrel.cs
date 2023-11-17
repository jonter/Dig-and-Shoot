using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    ParticleSystem burstVFX;

    // Start is called before the first frame update
    void Start()
    {
        burstVFX = GetComponentInChildren<ParticleSystem>();
        FindObjectOfType<BaseHealth>().OnDeath += MakeBoom;
    }

    private void OnDestroy()
    {
        FindObjectOfType<BaseHealth>().OnDeath -= MakeBoom;
    }

    protected virtual void MakeBoom()
    {
        //Проиграть звук взрыва
        burstVFX.transform.parent = null;
        burstVFX.Play();
        Destroy(gameObject);
    }

    
}
