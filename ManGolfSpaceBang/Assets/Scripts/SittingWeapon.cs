using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class name unclear. this script is for weapons that have not currently been 
public class SittingWeapon : MonoBehaviour, Pickupable
{

    [SerializeField] Weapon wep;
    [SerializeField] string weaponToBe;

    private void Start()
    {
        wep = GameObject.FindGameObjectsWithTag(weaponToBe)[0].GetComponent<Weapon>();
    }

    public void AssignWeapon(Weapon w)
    {
        //wep = GameObject.FindGameObjectsWithTag(weaponToBe)[0].GetComponent<Weapon>();
        wep = w;
    }

    public Weapon PickedUp()
    {
        Destroy(gameObject);
        return wep;

    }

}
