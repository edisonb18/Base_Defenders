using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public float firerate = 0.5f;
    public float spawnrate = 5f;
    private float nextAtt = 0F;
    private float nextSpw = 0F;
    private bool active = true;
    public Spawn sender;
    public Spawn center;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        nextAtt = Time.time + firerate;
        nextSpw = Time.time + spawnrate;
    }

    public void SetDificulty(float dificulty)
    {
        center.dificultyMultiplier= dificulty;
        sender.dificultyMultiplier = dificulty;
    }

    public void SetActive(bool state)
    {
        active = state;
    }
    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (Time.time >= nextAtt)
            {
                transform.rotation = Quaternion.Euler(0, Random.Range(-180, 180), 0);
                sender.SpawnSelecc();
                nextAtt = Time.time + 1f / firerate;
            }
            if (Time.time >= nextSpw)
            {
                transform.rotation = Quaternion.Euler(0, Random.Range(-180, 180), 0);
                center.SpawnSelecc();
                nextSpw = Time.time + 1f / spawnrate;
            }
        }
    }
}
