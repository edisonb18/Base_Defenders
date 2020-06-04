using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl : MonoBehaviour
{
    public Hurtbox nuke;
    public float firerate = 5f;
    public int Nukes=1;
    public GameObject Ship;
    public float bulletDamageMult = 1;
    public float bulletSpeedMult = 1;
    public float bulletFirerateMult = 1;
    public int bulletLevel = 0;
    private GameObject Base;
    private float nextAtt = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(9, 11);
        Physics.IgnoreLayerCollision(10, 11);
        Physics.IgnoreLayerCollision(12, 11);
        Base = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAtt && Input.GetButton("Fire2") && Nukes > 0)
        {
            Nukes--;
            nuke.Attack();
            nextAtt = Time.time + 1f / firerate;
        }
    }

    public void PowerUp(int powerId)
    {
        if(Ship!= null)
        {
            switch (powerId)
            {
                case 1:
                    Nukes++;
                    break;
                case 2:
                    bulletDamageMult += 0.1f;
                    Shot Dmg = Ship.GetComponentInChildren<Shot>();
                    if (Dmg != null)
                        Dmg.damageMultiplier = bulletDamageMult;
                    break;
                case 3:
                    bulletSpeedMult += 0.01f;
                    Shot Spd = Ship.GetComponentInChildren<Shot>();
                    if (Spd != null)
                        Spd.speedMultiplier = bulletDamageMult;
                    break;
                case 4:
                    bulletFirerateMult += 0.1f;
                    Shot Frt = Ship.GetComponentInChildren<Shot>();
                    if (Frt != null)
                        Frt.fireMultiplier = bulletFirerateMult;
                    break;
                case 5:
                    HpControl lifes = Ship.GetComponentInChildren<HpControl>();
                    if (lifes != null)
                        lifes.extraLife();
                    break;
                case 6:
                    HpControl baseHealth = Base.GetComponent<HpControl>();
                    if (baseHealth != null)
                        baseHealth.GainHealth(30);
                    break;
                case 7:
                    HpControl shpHealth = Ship.GetComponentInChildren<HpControl>();
                    if (shpHealth != null)
                        shpHealth.GainHealth(30);
                    break;
                case 8:
                    Shot Sprd = Ship.GetComponentInChildren<Shot>();
                    if (Sprd != null)
                        Sprd.SpreadLevelUp();
                    break;
                case 9:
                    BulletCollection bullLvl = Ship.GetComponentInChildren<BulletCollection>();
                    bullLvl.LevelUp();
                    break;
                default:
                    break;
            }
        }
    }
}
