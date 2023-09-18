using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    float speed = 20;
    bool isLaunched = false;
    float damage = 10;

    public void Launch()
    {
        rb = GetComponent<Rigidbody>();
        isLaunched = true;
        rb.isKinematic = false;
        rb.velocity = -transform.forward * speed;
        Destroy(gameObject, 5);
    }

    
}
