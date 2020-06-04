using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpControl : MonoBehaviour
{
    public int maxHealth = 100;
    public int lives = 1;
    public int actualHealth=100;
    public DropReward dropReward;
    private bool invul;
    private IEnumerator coroutine;

    //public GameObject deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        actualHealth = maxHealth;
        invul=false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (!invul)
        {
            actualHealth -= damage;
            // hurt animation
        }
            
        if (actualHealth <= 0)
        {
            loseLive();
            if (lives <= 0)
            {
                if (dropReward != null)
                {
                    dropReward.sendPowerUp();
                }
                Die();
            }
        }
    }

    public void extraLife()
    {
        lives++;
    }

    public void GainHealth(int health)
    {
        actualHealth = Mathf.Min(actualHealth + health, maxHealth);
    }

    public void Invulnerable(int time)
    {
        coroutine = NoDamage(time);
        StartCoroutine(coroutine);
    }

    IEnumerator NoDamage(int time)
    {
        invul = true;
        yield return new WaitForSeconds(time);
        invul = false;
    }

    void loseLive()
    {
        actualHealth = maxHealth;
        lives--;
        coroutine = NoDamage(4);
        StartCoroutine(coroutine);
        //LostLife animation
    }



    void Die()
    {
        //deathEffect
        Destroy(gameObject);
    }
}
