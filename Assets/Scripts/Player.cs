using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 15f;

    public PlayerProjectile laserPrefab;

    private bool laserShot;
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Projectile();
        }
    }

    private void Projectile()
    {
        if (!laserShot)
        {
            PlayerProjectile playerProjectile =Instantiate(laserPrefab, this.transform.position, Quaternion.identity);
            playerProjectile.projectileDestroyed += ProjectileDestroyed;
            laserShot = true;
        }
    }

    private void ProjectileDestroyed()
    {
        laserShot = false;
    }




}
