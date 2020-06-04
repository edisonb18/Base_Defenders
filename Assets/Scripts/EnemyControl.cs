using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject Body;
    public GameObject target;
    public float distance = 30f;
    public float firerate = 0f;
    public float spawnrate = 0f;
    public float rotationSpeed = 1f;
    public float aimSpeed= 1f; 
    public float aproximationSpeed = 1f;
    public float dificultyMultiplier=1;
    public bool following;
    public Spawn sender;
    public Shot gun;
    private float nextAtt = 0f;
    private float nextSpawn = 0f;
    private float actDistance=110;
    private bool onRange;
    private float nextMove;
    // Start is called before the first frame update
    void Start()
    {
        Body.transform.position = (Body.transform.position - transform.position).normalized * actDistance + transform.position;
        setTarget(target);
        onRange = false;
        nextAtt = Time.time + firerate;
        nextSpawn = Time.time + spawnrate;
    }

    // Update is called once per frame
    void Update()
    {
        if(Body != null){
            if (onRange)
            {
                if (Time.time >= nextSpawn && sender!=null)
                {
                    sender.SpawnSelecc();
                    nextSpawn = Time.time + 1f / (spawnrate * dificultyMultiplier);
                    nextMove = Time.time + 0.7f / dificultyMultiplier;
                }
                else if (Time.time >= nextAtt && gun != null)
                {
                    gun.Shoot();
                    nextAtt = Time.time + 1f / (firerate * dificultyMultiplier);
                    nextMove = Time.time + 0.3f/ dificultyMultiplier;
                }

            }
            if (target != null)
            {
                Aproximar();
                Seguir(Body, aimSpeed);
                if (Time.time >= nextMove)
                {
                    if (following)
                        Seguir(gameObject, rotationSpeed * dificultyMultiplier);
                    else
                        Huir(gameObject, rotationSpeed * dificultyMultiplier);
                }
            }
        }
        else
        {
            Die();
        }
    }
    public void setMultiplier(float mult)
    {
        dificultyMultiplier = mult;
        if (gun != null)
        {
            gun.damageMultiplier = dificultyMultiplier;
            gun.fireMultiplier = dificultyMultiplier;
            gun.speedMultiplier = dificultyMultiplier;
        }
        if (sender != null)
        {
            sender.dificultyMultiplier *= dificultyMultiplier;
        }
    }
    public void setTarget(GameObject newTarget)
    {
        if (newTarget != null)
        {
            target = newTarget;
            if(gun!=null)
                gun.setTarget(target);
            if(sender != null)
                sender.setTarget(target);
        }
        
    }
    void Aproximar()
    {
        if (actDistance > distance + 1)
        {
            actDistance -= aproximationSpeed * (1+ (dificultyMultiplier-1)*0.1f);
            Body.transform.position = (Body.transform.position - transform.position).normalized * actDistance + transform.position;
            onRange = false;
        }
            
        else if (actDistance < distance - 1)
        {
            actDistance += aproximationSpeed * dificultyMultiplier;
            Body.transform.position = (Body.transform.position - transform.position).normalized * actDistance + transform.position;
        }
        else
        {
            onRange = true;
        }
        
    }

    void Seguir(GameObject Agent, float speed)
    {
        Quaternion rotTarget = Quaternion.LookRotation(target.transform.position - Agent.transform.position);
        Agent.transform.rotation = Quaternion.RotateTowards(Agent.transform.rotation, rotTarget, speed * Time.deltaTime);
    }
    

    void Huir(GameObject Agent, float speed)
    {
        Quaternion rotTarget = Quaternion.Euler(0, 180, 0) * Quaternion.LookRotation(target.transform.position - Agent.transform.position);
        Agent.transform.rotation = Quaternion.RotateTowards(Agent.transform.rotation, rotTarget, speed * Time.deltaTime);
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
