using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchyBoi : Weapon
{

    [SerializeField] Transform origin;
    [SerializeField] Transform end;

    [SerializeField] Rigidbody2D endRb;

    private void Start()
    {
        endRb = end.GetComponent<Rigidbody2D>();
    }

    public override void Fire(Vector3 pos, Transform t)
    {

        base.Fire(pos, t);

        endRb.AddForce(t.forward.normalized * fireForce, ForceMode2D.Impulse);

    }

}
