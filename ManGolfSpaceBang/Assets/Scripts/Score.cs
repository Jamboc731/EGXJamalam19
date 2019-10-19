using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class Score : MonoBehaviour
{
    public GameObject[] players;
    public int[] playerLives = { 3, 3 };
    public string[] playerName = { "Billy Bob", "Bob Billy" };
    public string winText;
    [TextArea] public string[] insults;
    public GameObject losePanel;
    public Text winTextBox;
    public Text loseTextBox;

    private int[] cachedScore;

    public void LoseLife(int playerNo, int livesToLose)
    {
        playerLives[playerNo] -= livesToLose;
        Debug.Log(playerLives);
    }

    public void Lose(int playerToLose, int playerToWin)
    {
        int randomInsult = Random.Range(0, insults.Length);
        StringBuilder winner = new StringBuilder(playerName[playerToWin] + winText);
        StringBuilder loser = new StringBuilder(playerName[playerToLose] + insults[randomInsult]);
        losePanel.SetActive(true);
        winTextBox.text = winner.ToString();
        loseTextBox.text = loser.ToString();
    }

    public int GetCurrentLives(int player)
    {
        Debug.Log("Getting Lives" + playerLives[player]);
        return playerLives[player];
    }
}
