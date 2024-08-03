using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{

    [SerializeField] Image reloadImage;

    private void OnDestroy()
    {
        transform.DOKill();
        reloadImage.DOKill();
    }

}
