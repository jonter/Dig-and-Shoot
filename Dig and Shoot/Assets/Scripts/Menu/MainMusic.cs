using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainMusic : MonoBehaviour
{
    public static MainMusic instance;

    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip battleMusic;

    AudioSource audio;
    float volume = 1;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audio = GetComponent<AudioSource>();
            volume = audio.volume;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public static void SetMenuMusic()
    {
        if (instance == null) return;
        instance.StartCoroutine(instance.ChangeMusicCoroutine(instance.menuMusic));
    }

    public static void SetBattleMusic()
    {
        if (instance == null) return;
        instance.StartCoroutine(instance.ChangeMusicCoroutine(instance.battleMusic));
    }

    IEnumerator ChangeMusicCoroutine(AudioClip clip)
    {
        audio.DOFade(0, 1).SetUpdate(true);
        yield return new WaitForSeconds(1);
        audio.clip = clip;
        audio.Play();
        audio.DOFade(volume, 1).SetUpdate(true);
    }



}
