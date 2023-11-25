using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Sprite soundOn;
    [SerializeField] Sprite soundOff;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ToggleSound);
        int num = PlayerPrefs.GetInt("sound");
        if(num == 1)
        {
            icon.sprite = soundOff;
            AudioListener.volume = 0;
        }
    }

    void ToggleSound()
    {
        int num = PlayerPrefs.GetInt("sound");
        if(num == 0)
        {
            icon.sprite = soundOff;
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("sound", 1);
        }
        else
        {
            icon.sprite = soundOn;
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("sound", 0);
        }

    }

    
}
