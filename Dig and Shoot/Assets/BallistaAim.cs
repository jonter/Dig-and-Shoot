using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaAim : MonoBehaviour
{
    Camera myCamera;
    

    // Start is called before the first frame update
    void Start()
    {
        myCamera = Camera.main;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Aim();
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


}
