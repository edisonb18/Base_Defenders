using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float spawnTime= 4;
    public int damage = 40;
    private float startTime;
    public int ignoreLayer;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float t = Time.time - startTime;
        if (t >= spawnTime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        HpControl target = collision.collider.GetComponent<HpControl>();
        if (target != null)
        {
            if (collision.gameObject.layer != ignoreLayer)
            {
                target.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == gameObject.layer)
            Destroy(gameObject);
    }
}
