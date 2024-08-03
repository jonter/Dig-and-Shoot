using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    protected Rigidbody rb;
    protected Animator anim;

    [SerializeField] float speed = 3;
    [SerializeField] float attackDistance = 1;
    [SerializeField] protected float damage = 10;

    protected BaseHealth target = null;
    protected bool isFrozen = false;

    SkinnedMeshRenderer mesh;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.velocity = transform.forward * speed;
    }

    private void OnDisable()
    {
        if (rb == null) return;
        rb.velocity = new Vector3();

    }

    public IEnumerator FreezeEnemyCoroutine(float duration)
    {
        if (rb.velocity.magnitude < 0.1f) yield break; 
        mesh.material.SetInt("_frozen", 1);
        rb.velocity = new Vector3();
        anim.enabled = false;
        isFrozen = true;
        yield return new WaitForSeconds(duration);
        anim.enabled = true;
        isFrozen = false;
        mesh.material.SetInt("_frozen", 0);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isFrozen == true) return;
        Vector3 origin = transform.position;
        Vector3 dir = transform.forward;
        LayerMask baseLayer = LayerMask.GetMask("Base");
        RaycastHit hitInfo;
        Physics.Raycast(origin, dir, out hitInfo, attackDistance, baseLayer);
        if(hitInfo.transform)
        {
            target = hitInfo.transform.GetComponent<BaseHealth>();
            rb.velocity = new Vector3(0, 0, 0);
            anim.SetBool("attack", true);
        }
        else
        { 
            rb.velocity = transform.forward * speed;
            anim.SetBool("attack", false);
        }
        
    }

    public virtual void Attack()
    {
        if (target == null) return;
        target.GetDamage(damage);

    }

}
