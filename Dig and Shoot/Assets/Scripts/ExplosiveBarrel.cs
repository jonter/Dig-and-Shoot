using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    ParticleSystem burstVFX;
    [SerializeField] AudioClip burstSound;
    BaseHealth bHealth;
    // Start is called before the first frame update
    void Start()
    {
        burstVFX = GetComponentInChildren<ParticleSystem>();
        bHealth= FindObjectOfType<BaseHealth>();
        bHealth.OnDeath += MakeBoom;
    }

    private void OnDisable()
    {
        bHealth.OnDeath -= MakeBoom;
    }

    protected virtual void MakeBoom()
    {
        AudioSource.PlayClipAtPoint(burstSound, Camera.main.transform.position);

        burstVFX.transform.parent = null;
        burstVFX.Play();
        Destroy(gameObject);
    }

    
}
