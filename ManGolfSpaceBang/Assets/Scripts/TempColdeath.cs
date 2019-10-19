using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempColdeath : MonoBehaviour
{
    //meant to be temp for black hole enter 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Debug.Log("Player fell into the hole");
    }

}
