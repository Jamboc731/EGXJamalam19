using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    int fartsInChamber = 3;

    [Tooltip("The force exerted on the player when they do a cute lil toot in their soot")]
    [SerializeField] float tootForce;

    Rigidbody2D rb;

    float xIn;

    [Tooltip("The rotational torque applied to the player")]
    [SerializeField] float rotT;

    [Tooltip("What player number is this?")]
    [SerializeField] char playerNo;

    string hor;
    string fire;
    string toot;

    Weapon equipped;

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        hor = string.Concat(playerNo, "Horizontal");
        fire = string.Concat(playerNo, "Fire");
        toot = string.Concat(playerNo, "Toot");

        rb.angularDrag = 0;
    }

    private void Update()
    {
        xIn = Input.GetAxisRaw(hor);
        if (Input.GetButtonDown(fire)) Fire();
        if (Input.GetButtonDown(toot)) Toot();
    }

    private void FixedUpdate()
    {
        rb.AddTorque(-xIn * rotT);
    }

    public void Fire()
    {
        Debug.Log("player " + playerNo + " fired");

        if (equipped != null) equipped.Fire(); 

    }

    public void Toot()
    {
        rb.AddForce(transform.right * tootForce, ForceMode2D.Impulse);
    }

    public void PickUp(Weapon pickedUp)
    {
        equipped = pickedUp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Pickupable a = collision.gameObject.GetComponent<Pickupable>();
        if (a != null)
        {
            PickUp(a.PickedUp());
        }
    }

}
