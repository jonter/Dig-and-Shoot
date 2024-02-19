using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    ParticleSystem burstVFX;
    [SerializeField] AudioClip burstSound;

    // Start is called before the first frame update
    void Start()
    {
        burstVFX = GetComponentInChildren<ParticleSystem>();
        FindObjectOfType<BaseHealth>().OnDeath += MakeBoom;
    }

    private void OnDisable()
    {
        FindObjectOfType<BaseHealth>().OnDeath -= MakeBoom;
    }

    protected virtual void MakeBoom()
    {
        AudioSource.PlayClipAtPoint(burstSound, Camera.main.transform.position);

        burstVFX.transform.parent = null;
        burstVFX.Play();
        Destroy(gameObject);
    }

    
}
