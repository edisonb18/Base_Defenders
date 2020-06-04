using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimcontroll : MonoBehaviour
{
    Camera mainCamera;
    Vector3 mousePos;

    public Shot gun;
    private bool stunned;
    private bool keepFire;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        stunned=false;
        keepFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gun != null && !stunned)
        {
            mousePos = Input.mousePosition;
            mousePos.z = mainCamera.transform.position.y;
            Vector3 Pos = mainCamera.ScreenToWorldPoint(mousePos);
            Pos.y = 0;
            transform.LookAt(Pos);
            if ( Input.GetButton("Fire1") || keepFire)
            {
                gun.Shoot();
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (keepFire)
                keepFire = false;
            else
                keepFire = true;
        }
        
    }

    public IEnumerator Stunned(int time)
    {
        stunned = true;
        yield return new WaitForSeconds(time);
        stunned = false;
    }


}

