using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropReward : MonoBehaviour
{
    public int points = 10;
    public Transform posicion;
    public GameObject[] drops;
    public GameObject rewardDrop;
    public LevelControl control;
    public float DropChance = 0.5f;
    public int SecureDrops = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void sendPowerUp()
    {
        control.AddPoints(points);
        if (rewardDrop != null)
        {
            send(rewardDrop);
        }
        if (drops.Length > 0)
        {
            for (int i = 0; i < SecureDrops; i++)
            {
                send(drops[Random.Range(0, drops.Length)]);
            }
            float temp = Random.Range(0f, 1f);
            if (temp <= DropChance)
            {
                send(drops[Random.Range(0, drops.Length)]);
            }
        }
        
    }

    void send(GameObject reward)
    {
        GameObject bullet = Instantiate(reward, posicion.position, Quaternion.Euler(0, Random.Range(0f, 360f),0));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(posicion.forward * 5, ForceMode.Impulse);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
