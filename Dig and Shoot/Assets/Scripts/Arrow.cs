using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    float speed = 25;
    protected bool isLaunched = false;
    protected float damage = 10;

    public virtual void Launch()
    {
        damage = GameStats.GetDamage();
        rb = GetComponent<Rigidbody>();
        isLaunched = true;
        rb.isKinematic = false;
        rb.velocity = -transform.forward * speed;
        Destroy(gameObject, 5);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (isLaunched == false) return;

        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if(enemy != null)
        {
            enemy.GetDamage(damage);
            Destroy(gameObject);
        }
        
    }


}
