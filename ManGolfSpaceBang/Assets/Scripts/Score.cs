using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    //editforpushpleaseeee0
    public GameObject[] players;
    public int[] playerLives = { 3, 3 };
    public string[] playerName = { "Billy Bob", "Bob Billy" };
    public string winText;
    [TextArea] public string[] insults;
    public GameObject losePanel;
    public GameObject player1Win;
    public GameObject player2Win;

    private int[] cachedScore;

    public void LoseLife(int playerNo, int livesToLose)
    {
        playerLives[playerNo] -= livesToLose;
        Debug.Log(playerLives);
    }

    public void Lose(int playerToLose)
    {
        Time.timeScale = 0;
        //int randomInsult = Random.Range(0, insults.Length);
        if(playerToLose == 0)
        {
            player1Win.SetActive(true);
        }
        else if (playerToLose == 1)
        {
            player2Win.SetActive(true);
        }
        losePanel.SetActive(true);
    }

    public int GetCurrentLives(int player)
    {
        Debug.Log("Getting Lives" + playerLives[player]);
        return playerLives[player];
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
