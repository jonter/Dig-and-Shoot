using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    Animator anim;
    [SerializeField] float hp = 50;
    bool isAlive = true;
    [SerializeField] int coinsForKill = 5;
    Slider healthBar;
    float maxHP;

    SkinnedMeshRenderer mesh;

    public void IncreaseHP(float hpMult)
    {
        hp = hp * hpMult;
        maxHP = hp;
    }

    public void IncreaseCoins(float coinsMult)
    {
        coinsForKill =  (int)(coinsForKill * coinsMult);
    }

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        maxHP = hp;
        anim = GetComponent<Animator>();
        healthBar = GetComponentInChildren<Slider>();
        healthBar.gameObject.SetActive(false);
    }

    public void GetDamage(float damage)
    {
        if (isAlive == false) return;

        hp -= damage;
        healthBar.gameObject.SetActive(true);
        healthBar.value = hp / maxHP;

        if(hp <= 0.0001f)
        {
            Death();
        }

    }

    void Death()
    {
        StartCoroutine(DissolveCoroutine());
        isAlive = false;
        GetComponent<EnemyBrain>().enabled = false;
        GetComponent<Collider>().enabled = false;
        healthBar.gameObject.SetActive(false);

        int rand = Random.Range(0, 2);
        if (rand == 0) anim.SetTrigger("death1");
        else anim.SetTrigger("death2");

        Destroy(gameObject, 5);
        FindObjectOfType<MoneyManager>().AddCoins(coinsForKill);
    }


    IEnumerator DissolveCoroutine()
    {
        yield return new WaitForSeconds(2.5f);
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;

            mesh.material.SetFloat("_transparency", t);
            yield return null;
        }

    }

}
