using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;

    [SerializeField] float speed = 3;
    [SerializeField] float attackDistance = 1;
    [SerializeField] float damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.velocity = transform.forward * speed;
    }

    private void OnDisable()
    {
        rb.velocity = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 dir = transform.forward;
        LayerMask baseLayer = LayerMask.GetMask("Base");
        RaycastHit hitInfo;
        Physics.Raycast(origin, dir, out hitInfo, attackDistance, baseLayer);
        if(hitInfo.transform)
        {
            rb.velocity = new Vector3(0, 0, 0);
            anim.SetBool("attack", true);
        }
        else
        {
            rb.velocity = transform.forward * speed;
            anim.SetBool("attack", false);
        }
        
    }
}
