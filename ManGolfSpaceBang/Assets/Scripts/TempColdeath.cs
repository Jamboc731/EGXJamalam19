using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempColdeath : MonoBehaviour
{
    //meant to be temp for black hole enter 
    public GameObject[] playerSpawns;
    int[] playerLives = {0, 0};

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            if(playerLives[0] < 3)
                other.gameObject.transform.position = playerSpawns[0].transform.position;
            playerLives[0]++;
        }
        else if (other.gameObject.tag == "Player2")
        {
            other.gameObject.transform.position = playerSpawns[1].transform.position;
            playerLives[1]++;
        }
    }

}
