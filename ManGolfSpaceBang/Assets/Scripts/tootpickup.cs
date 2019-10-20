﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tootpickup : MonoBehaviour
{
    int numberOfToots;

    private void Start()
    {
        numberOfToots = 3;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player !=null)
        {
            player.AddToChamber(numberOfToots);
            this.gameObject.SetActive(false);
        }
    }
    
}
