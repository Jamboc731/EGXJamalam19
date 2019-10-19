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
    [SerializeField] Vector3 firePoint;

    Rigidbody2D pRb; //projectile rb
    Transform pT; // projectile transform

    public override void Fire(Vector3 pos, Quaternion rot)
    {
        base.Fire(pos, rot);

        for (int i = 0; i < projectileCount; i++)
        {
            pT = Instantiate(projectilePrefab, pos + firePoint, transform.rotation).transform;
            Destroy(pT.gameObject, pLifetime);
            //Debug.Log(pRb);
            //Debug.Log((firePoint + (firePoint * (spread / 45))).normalized);
            //transform.rotation = Quaternion.AngleAxis(Random.Range(-spread/2, spread/2), Vector3.forward);
            pT.GetComponent<Projectile>().Fired(fireForce * (1 - forceRatio), (transform.right + (transform.up * spread /45 )).normalized);
            //Debug.Log(pT.forward * fireForce * (1 - forceRatio));


        }

    }


}
