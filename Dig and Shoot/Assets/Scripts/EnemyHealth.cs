using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Animator anim;
    [SerializeField] float hp = 50;
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void GetDamage(float damage)
    {
        if (isAlive == false) return;

        hp -= damage;

        if(hp <= 0.0001f)
        {
            Death();
        }

    }

    void Death()
    {
        isAlive = false;
        GetComponent<EnemyBrain>().enabled = false;

        int rand = Random.Range(0, 2);
        if (rand == 0) anim.SetTrigger("death1");
        else anim.SetTrigger("death2");

        Destroy(gameObject, 5);
    }

}
