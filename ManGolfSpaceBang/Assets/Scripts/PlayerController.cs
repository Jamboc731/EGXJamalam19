using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] int fartsInChamber = 3;

    [Tooltip("The force exerted on the player when they do a cute lil toot in their soot")]
    [SerializeField] float tootForce;

    [SerializeField] Transform weaponPoint;

    Rigidbody2D rb;

    [SerializeField] Transform firePoint;

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

        if (equipped != null) equipped.Fire(transform.position, firePoint.transform);
        rb.AddForce(-transform.right * equipped.GetFireForce());

    }

    public void Toot()
    {
        if(fartsInChamber > 0)
        {
            rb.AddForce(transform.right * tootForce, ForceMode2D.Impulse);
            fartsInChamber--;
        }
    }

    public void PickUp(Weapon pickedUp)
    {
        equipped = pickedUp;
        GameObject t = Instantiate(equipped.Model(), weaponPoint.transform);
        t.transform.localPosition = Vector3.zero;
        t.transform.localEulerAngles = new Vector3(0, 90, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Pickupable a = collision.gameObject.GetComponent<Pickupable>();
        if (a != null)
        {
            PickUp(a.PickedUp());
        }
    }

    /// <summary>
    /// Adds "val" to FartsInChamber 
    /// </summary>
    /// <param name="val"></param>
    public void AddToChamber(int val)
    {
        fartsInChamber += val;
    }

    public void ApplyForce(Vector2 force)
    {
        rb.AddForce(force);
    }

}
