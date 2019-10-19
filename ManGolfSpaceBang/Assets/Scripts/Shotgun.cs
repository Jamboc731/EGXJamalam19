using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{

    [Range(1, 15)]
    [SerializeField] int projectileCount = 5;

    [Tooltip("The time before the projectile is destroyed")]
    [SerializeField] float pLifetime;

    [Tooltip("The maximum spread, in degrees, that the projectiles will go have *max 45*")]
    [Range(0, 45)]
    [SerializeField] float spread;
    
    [SerializeField] GameObject projectilePrefab;

    [Tooltip("The point that the projectiles will originate from")]
    [SerializeField] Transform firePoint;

    Rigidbody2D pRb; //projectile rb
    Transform pT; // projectile transform

    public override void Fire()
    {
        base.Fire();

        for (int i = 0; i < projectileCount; i++)
        {
            //pT = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity).transform;
            //pRb = pT.GetComponent<Rigidbody2D>();

            //transform.rotation = Quaternion.LookRotation((firePoint.right + (firePoint.up * (spread / 45))).normalized);

            //pRb.AddForce(pT.forward * fireForce * (1-forceRatio), ForceMode2D.Impulse);
            

        }

    }


}
