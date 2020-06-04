using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float extraSpeed;
    private Vector3 direction;
    public bool timed;
    public float timeAccel;
    public Rigidbody rb;
    private float timer;

    void Start()
    {
        direction = Vector3.zero;
        timer = Time.time + timeAccel;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce((direction - transform.position).normalized * speed * Time.smoothDeltaTime);
        if (timed && Time.time >= timer)
        {
            speed += extraSpeed;
        }
    }
}
