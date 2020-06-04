using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public int PowerID;
    private float pauseImpulse=6f;
    private float next=0f;

    void Start()
    {
        next = Time.time + 6f;
    }
    void FixedUpdate()
    {
        if (Time.time >= next)
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce((Vector3.zero - transform.position).normalized * 25);
            next = Time.time + pauseImpulse;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        BaseControl target = collision.collider.GetComponent<BaseControl>();
        if (target != null)
        {
            target.PowerUp(PowerID);
            //Animacion power up
            Destroy(gameObject);
        }
    }
}
