using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomItemSpawn : MonoBehaviour
{
    //editforpush
    [SerializeField] GameObject[] spawnPoints;
    [Tooltip("Make sure Shotgun is in pos 0 of array and Boxing Glove is in pos 1 of array")]
    [SerializeField] GameObject[] items;

    private Transform childCheck;
    void Start()
    {
        SpawnObjects();
    }

    public void SpawnObjects()
    {

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i == 0)
            {
                int randomSpawn = Random.Range(0, spawnPoints.Length);
                Instantiate(items[0], spawnPoints[randomSpawn].transform);
                /*if (items[0].transform.childCount > 1)
                {
                    Destroy(items[0]);
                }*/
            }
            else if (i == 1)
            {
                int randomItem = Random.Range(0, items.Length);
                int randomSpawn = Random.Range(0, spawnPoints.Length);
                Instantiate(items[1], spawnPoints[randomSpawn].transform);
                /*if (items[1].transform.childCount > 1)
                {
                    Destroy(items[1]);
                }*/
            }
            else if (i != 1 || i != 2)
            {
                int randomItem = Random.Range(0, items.Length);
                int randomSpawn = Random.Range(0, spawnPoints.Length);
                GameObject ItemToSpawn = Instantiate(items[randomItem], spawnPoints[randomSpawn].transform) as GameObject;
                /*if (spawnPoints[randomSpawn].transform.childCount > 1)
                {
                    Destroy(spawnPoints[randomItem].transform.GetChild(0));
                }*/
            }
        }
    }

    public void DestroyItems()
    {
        GameObject[] destroyableWeapon = GameObject.FindGameObjectsWithTag("WeaponPickup");
        GameObject[] destroyableItem = GameObject.FindGameObjectsWithTag("Item");
        foreach(GameObject item in destroyableWeapon)
        {
            Destroy(item);
        }

        foreach (GameObject item in destroyableItem)
        {
            Destroy(item);
        }
    }
}
