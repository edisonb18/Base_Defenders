using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform []firepoints;
    public SpawnCollection Pool;
    public GameObject target;
    public LevelControl control;
    public float sendForce;
    public float dificultyMultiplier = 1f;
    private GameObject enemyPrefab;
    

    // Update is called once per frame

    public void SpawnSelecc ()
    {
        enemyPrefab = Pool.GetObject();
        Send();
    }
    public void setTarget(GameObject newTarget)
    {
        if (newTarget != null)
            target = newTarget;
    }
    void Send()
    {
        foreach (Transform firepoint in firepoints)
        {
            GameObject bullet = Instantiate(enemyPrefab, firepoint.position, firepoint.rotation);
            EnemyControl Ai = bullet.GetComponent<EnemyControl>();
            if (Ai != null&&target != null)
            {
                Ai.setTarget(target);
                Ai.setMultiplier(dificultyMultiplier);
            }
            DropReward Rw = bullet.GetComponentInChildren<DropReward>();
            if (Rw != null)
                Rw.control = control;
            Bullet Bll = bullet.GetComponent<Bullet>();
            if (Bll != null)
                Bll.damage = (int)(Bll.damage * dificultyMultiplier);
            Spawn Sp = bullet.GetComponentInChildren<Spawn>();
            if (Sp != null)
                Sp.control = control;
            Rigidbody Rb = bullet.GetComponent<Rigidbody>();
            if (Rb!=null)
                Rb.AddForce(firepoint.forward * sendForce, ForceMode.Impulse);
        }
    }
}
