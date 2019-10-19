using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{


    [Tooltip("The force exerted by this weapon")]
    [SerializeField] protected float fireForce;
    [Tooltip("The ratio of the force that goes into the player. e.g. 0.5f makes half the force go to the player and half to the projectile")]
    [Range(0f, 1f)]
    [SerializeField] protected float forceRatio;
    [Tooltip("The model that this weapon will use")]
    [SerializeField] protected GameObject model;

    public virtual void Fire(Vector3 pos, Transform t)
    {
        Debug.Log(gameObject.name + " was fired");
    }

    public float GetFireForce()
    {
        return fireForce * forceRatio;
    }

    public GameObject Model()
    {
        Debug.Log("got model");
        return model;
    }

}
