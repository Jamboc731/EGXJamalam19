using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody2D rb;
    
    public void Fired(float force, Vector2 dir)
    {
        StartCoroutine(WaitForCollide());
        //Debug.Log(Quaternion.AngleAxis(Random.Range(-15, 15), Vector3.forward));
        //transform.rotation = Quaternion.AngleAxis(Random.Range(-15, 15), Vector3.forward);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(dir * force);

    }

    IEnumerator WaitForCollide()
    {
        GetComponent<Collider2D>().isTrigger = true;
        yield return new WaitForSeconds(0.05f);
        GetComponent<Collider2D>().isTrigger = false;
    }

}
