using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TransitionPanel : MonoBehaviour
{
    public static TransitionPanel instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void HidePanel()
    {
        if (instance == null) return;
        Image img = instance.transform.GetChild(0).GetComponent<Image>();
        Color endColor = img.color;
        endColor.a = 0;
        img.DOColor(endColor, 1).SetUpdate(true);

    }

    public static void ShowPanel()
    {
        if (instance == null) return;
        Image img = instance.transform.GetChild(0).GetComponent<Image>();
        Color endColor = img.color;
        endColor.a = 1;
        img.DOColor(endColor, 1).SetUpdate(true);

    }


}
