using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class name unclear. this script is for weapons that have not currently been 
public class SittingWeapon : MonoBehaviour, Pickupable
{

    Weapon wep;

    public void AssignWeapon(Weapon w)
    {
        wep = w;
    }

    public Weapon PickedUp()
    {
        Destroy(gameObject);
        return wep;

    }

}
