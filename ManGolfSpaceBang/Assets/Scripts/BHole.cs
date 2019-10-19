using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHole : MonoBehaviour
{

    [Tooltip("The radius at which the hole starts asserting dominance of the players")]
    [SerializeField] float bHoleRadius;

    [Tooltip("The dominating power of the bHole")]
    [SerializeField] float power;

    List<PlayerController> players = new List<PlayerController>();

    private void Start()
    {
        foreach (var g in GameObject.FindObjectsOfType<PlayerController>())
        {
            players.Add(g);
        }
    }

    private void FixedUpdate()
    {
        foreach (var i in players)
        {
            Vector2 t = i.transform.position;
            if(t.magnitude < bHoleRadius)
            {
                i.ApplyForce(t.normalized * power);
            }
        }
    }

}
