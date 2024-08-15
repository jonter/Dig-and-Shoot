using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIFader : MonoBehaviour
{
    [SerializeField] float animDelay = 0.25f;
    [SerializeField] float animTime = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        Image img = GetComponent<Image>();
        TMP_Text text = GetComponent<TMP_Text>();
        if (img != null)
        {
            Color c = img.color;
            c.a = 0;
            img.color = c;
            c.a = 1;
            img.DOColor(c, animTime).SetDelay(animDelay);
        }
        if(text != null)
        {
            Color c = text.color;
            c.a = 0;
            text.color = c;
            c.a = 1;
            text.DOColor(c, animTime).SetDelay(animDelay);
        }
        
    }

    
}
