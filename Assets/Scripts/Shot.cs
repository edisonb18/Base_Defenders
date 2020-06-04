using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform []firepoints;
    public BulletCollection bulletPrefab;
    public GameObject target;
    public float turrentRotationSpeed;
    public float bulletForce;
    public float damageMultiplier=1f;
    public float speedMultiplier = 1f;
    public float fireMultiplier = 1f;
    public float firerate = 2f;
    public bool playerStat;
    public int spreadLevel = 0;
    private Transform[] activeFirepoints;
    private int spreadlong=1;
    private float nextAtt = 0F;
    // Update is called once per frame
    void Start()
    {
        SpreadLevelReset();
    }
    void Update()
    {
        if (target != null)
        {
            Seguir();
        }
    }
    public void setTarget(GameObject newTarget)
    {
        if (newTarget != null)
            target = newTarget;
    }
    public void SpreadLevelUp()
    {
        if (spreadLevel < 5)
        {
            spreadLevel++;
            if (spreadLevel == 2)
            {
                activeFirepoints = new Transform[2];
                activeFirepoints[0] = firepoints[1];
                activeFirepoints[1] = firepoints[2];
            }
            else
            {
                if (spreadlong < 7)
                    spreadlong += 2;
                else
                    spreadlong = 7;
                activeFirepoints = new Transform[spreadlong];
                copyN(spreadlong);
            }
        }
    }
    public void SpreadLevelDown()
    {
        

        if (spreadLevel > 1)
        {
            spreadLevel--;
            if (spreadLevel == 2)
            {
                activeFirepoints = new Transform[2];
                activeFirepoints[0] = firepoints[1];
                activeFirepoints[1] = firepoints[2];
            }
            else
            {
                if (spreadlong > 1)
                    spreadlong -= 2;
                else
                    spreadlong = 1;
                activeFirepoints = new Transform[spreadlong];
                copyN(spreadlong);
            }
        }
    }
    public void SpreadLevelReset()
    {
        activeFirepoints = new Transform[1];
        activeFirepoints[0] = firepoints[0];
    }

    private void copyN(int n)
    {
        for (int i= 0; i < n ; i++)
        {
            activeFirepoints[i]= firepoints[i];
        }
    }

    void Seguir()
    {
        Quaternion rotTarget = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, turrentRotationSpeed * Time.deltaTime);
    }
    public void Shoot()
    {
        if(Time.time >= nextAtt)
        {
            if (playerStat)
            {
                foreach (Transform firepoint in activeFirepoints)
                {
                    GameObject bullet = Instantiate(bulletPrefab.GetObject(), firepoint.position, firepoint.rotation);
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.AddForce(firepoint.forward * bulletForce * speedMultiplier, ForceMode.Impulse);
                    bullet.GetComponent<Bullet>().damage = (int)(bullet.GetComponent<Bullet>().damage * damageMultiplier);
                }
                nextAtt = Time.time + 1f / (firerate* fireMultiplier);
            }
            else
            {
                foreach (Transform firepoint in firepoints)
                {
                    GameObject bullet = Instantiate(bulletPrefab.GetObject(), firepoint.position, firepoint.rotation);
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    rb.AddForce(firepoint.forward * bulletForce * (1+(speedMultiplier-1)*0.1f), ForceMode.Impulse);
                    bullet.GetComponent<Bullet>().damage = (int)(bullet.GetComponent<Bullet>().damage * damageMultiplier);
                }
                nextAtt = Time.time + 1f / (firerate * fireMultiplier);
            }
            
        }
        
        
    }
}
