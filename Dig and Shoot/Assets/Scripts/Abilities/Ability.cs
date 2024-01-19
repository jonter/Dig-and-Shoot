using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected Button skillButton;
    protected float reloadTime = 30;
    protected bool isReloaded = true;
    protected Image reloadPanel;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        skillButton.onClick.AddListener(Activate);
        reloadPanel = skillButton.transform.GetChild(1).GetComponent<Image>();
        reloadPanel.fillAmount = 0;
        FindObjectOfType<BaseHealth>().OnDeath += DeactivateAbility;
        FindObjectOfType<EnemySpawner>().OnWin += DeactivateAbility;
    }

    void DeactivateAbility()
    {
        isReloaded = false;
        enabled = false;
    }

    protected virtual void Activate()
    {

    }

    protected virtual void Reload()
    {
        reloadPanel.fillAmount = 1;
        reloadPanel.DOFillAmount(0, reloadTime).SetEase(Ease.Linear);
        StartCoroutine(ReloadCoroutine());
    }

    IEnumerator ReloadCoroutine()
    {
        isReloaded = false;
        yield return new WaitForSeconds(reloadTime);
        isReloaded = true;
    }
    
}
