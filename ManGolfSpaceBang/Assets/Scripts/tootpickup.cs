using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tootpickup : MonoBehaviour
{
    int numberOfToots;

    private void Start()
    {
        numberOfToots = Random.Range(0, 3);
    }

    private void OnTriggerEnter2D (Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player !=null)
        {
            player.AddToChamber(numberOfToots);
            this.gameObject.SetActive(false);
        }
    }
    
}
