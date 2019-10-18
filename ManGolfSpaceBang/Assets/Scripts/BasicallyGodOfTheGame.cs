using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* oh hey yeah jamie btw you're a dumb slut! ya see those weapons that you want to work? and the array that you had before which didnt work.  
    yeah they need to be on a FUCKING GAME OBJECT. FFS. if you were any dumber then you'd think that an int could handle decimal points and 
    if you were any sluttier then youd be like a well used bucket
*/
public class BasicallyGodOfTheGame : MonoBehaviour
{

    [SerializeField] Shotgun shotgun;
    [SerializeField] PunchyBoi punch;

    List<Pickupable> spawns;

    private void Start()
    {
        spawns = new List<Pickupable>();

        foreach (var i in GameObject.FindGameObjectsWithTag("WeaponPickup"))
        {

            Pickupable t = i.GetComponent<Pickupable>();
            

            if(t != null)
            {
                spawns.Add(t);
            }

        }

        spawns[0].AssignWeapon(shotgun);
        //spawns[1].AssignWeapon(punch);

    }

}
