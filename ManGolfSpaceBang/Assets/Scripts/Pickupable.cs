using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Pickupable
{

    Weapon PickedUp();

    void AssignWeapon(Weapon w);

}
