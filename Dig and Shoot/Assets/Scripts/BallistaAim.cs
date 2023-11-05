using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class BallistaAim : MonoBehaviour
{
    Camera myCamera;

    Arrow currentArrow;
    [SerializeField] GameObject arrowPrefab;

    float fireRate = 2;
    bool isReloaded = true;

    Vector3 startPos;
    Quaternion startRot;

    [SerializeField] Transform handle;
    [SerializeField] Transform starter;
    float animSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animSpeed = 1 / fireRate;
        currentArrow = GetComponentInChildren<Arrow>(); 
        myCamera = Camera.main;

        startPos = currentArrow.transform.localPosition;
        startRot = currentArrow.transform.localRotation;

        FindObjectOfType<BaseHealth>().OnDeath += DisableBallista;
        FindObjectOfType<EnemySpawner>().OnWin += DisableBallista;
    }

    void DisableBallista()
    {
        enabled = false;
    }

    private void OnDisable()
    {
        starter.DOKill();
        handle.DOKill();
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale <= 0.1f) return;
        if (EventSystem.current.IsPointerOverGameObject() == true) return;

        if (Input.GetMouseButton(0))
        {
            Aim();
            StartCoroutine(ShootCoroutine());
        }
    }

    void Aim()
    {
        Ray r = myCamera.ScreenPointToRay(Input.mousePosition);
        float distance = 100;
        LayerMask aimLayer = LayerMask.GetMask("Aim");
        RaycastHit hitInfo;
        Physics.Raycast(r, out hitInfo, distance, aimLayer);
        if (hitInfo.transform == null) return;

        Vector3 dir = hitInfo.point - transform.position;
        transform.right = dir;
        transform.Rotate(-90, 0, 0);
    }


    IEnumerator ShootCoroutine()
    {
        if (isReloaded == false) yield break;
        currentArrow.Launch();
        currentArrow.transform.parent = null;
        isReloaded = false;
        MakeShootAnim();
        yield return new WaitForSeconds(1 / fireRate);

        GameObject newArrow = Instantiate(arrowPrefab, transform);
        newArrow.transform.localPosition = startPos;
        newArrow.transform.localRotation = startRot;
        currentArrow = newArrow.GetComponent<Arrow>();
        isReloaded = true;
    }

    void MakeShootAnim()
    {
        starter.DOLocalMoveX(0, animSpeed / 2).SetLoops(2, LoopType.Yoyo);
        float oldRot = handle.localRotation.eulerAngles.y;

        handle.DOLocalRotate(new Vector3(0, oldRot+180, 0), animSpeed);
    }

}
