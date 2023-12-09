using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class BarrelAbility : Ability
{
    [SerializeField] BarrelWithDamage barrel;
    [SerializeField] GameObject barrelPrefab;
    [SerializeField] Transform trolley;

    Vector3 startBarrelPos;
    bool isActive = false;

    [SerializeField] GameObject aimPoint;
    float damage = 100;

    protected override void Start()
    {
        reloadTime = GameStats.GetReloadTime("burst");
        damage = GameStats.GetBurstDamage();
        if (reloadTime == 0 || reloadTime > 1000)
        {
            skillButton.gameObject.SetActive(false);
        }
        base.Start();
    }

    protected override void Activate()
    {
        if (isReloaded == false) return;
        if (isActive == true) return;
        skillButton.transform.DOScale(1.05f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
        isActive = true;
        Time.timeScale = 0.1f;

    }

    private void Update()
    {
        if (isActive == false) return;
        if (EventSystem.current.IsPointerOverGameObject() == true) return;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Aim();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            barrel.Launch(aimPoint.transform.position, damage);
            aimPoint.SetActive(false);
            Time.timeScale = 1;
            isActive = false;
            Reload();
            skillButton.transform.DOKill();
            skillButton.transform.DOScale(1, 0.5f);
            StartCoroutine(CreateNewBarrel());
        }


    }


    IEnumerator CreateNewBarrel()
    {
        startBarrelPos = barrel.transform.localPosition;
        yield return new WaitForSeconds(3);
        Vector3 newPos = trolley.position - trolley.forward * 10;
        trolley.DOMove(newPos, 3).SetLoops(2, LoopType.Yoyo);
        yield return new WaitForSeconds(3);
        GameObject clone = Instantiate(barrelPrefab, trolley);
        clone.transform.localPosition = startBarrelPos;
        clone.transform.localRotation = Quaternion.Euler(45, 0, 0);
        barrel = clone.GetComponent<BarrelWithDamage>();

    }

    void Aim()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance = 100;
        LayerMask aimLayer = LayerMask.GetMask("Aim");
        RaycastHit hitInfo;
        Physics.Raycast(r, out hitInfo, distance, aimLayer);
        if (hitInfo.transform)
        {
            aimPoint.SetActive(true);
            aimPoint.transform.position = hitInfo.point;
        }

    }




}
