using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{

    public Transform hurtbox;
    public float range = 0.1f;
    public LayerMask objectives;
    public float damage = 20;

    // Update is called once per frame
    public void Attack()
    {
        Collider[] targets = Physics.OverlapSphere(hurtbox.position, range, objectives);
        foreach (Collider target in targets)
        {
            target.GetComponent<HpControl>().TakeDamage((int)damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (hurtbox == null)
            return;
        Gizmos.DrawWireSphere(hurtbox.position, range);
    }
}
