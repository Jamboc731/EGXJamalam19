using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempColdeath : MonoBehaviour
{
    //editforpush
    [SerializeField] GameObject[] playerSpawns;
    [SerializeField] Score score;
    [SerializeField] RandomItemSpawn spawn;
    [SerializeField] GameObject roundOverPanel;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            if (score.GetCurrentLives(0) > 0)
            {
                PlayerOut(0);
                roundOverPanel.SetActive(true);
            }
            else if (score.GetCurrentLives(0) == 0)
            {
                other.gameObject.SetActive(false);
                score.Lose(0, 1);
            }
        }
        else if (other.gameObject.tag == "Player2")
        {
            if (score.GetCurrentLives(1) > 0)
            {
                PlayerOut(1);
                roundOverPanel.SetActive(true);
            }
            else if (score.GetCurrentLives(1) == 0)
            {
                other.gameObject.SetActive(false);
                score.Lose(1, 0);
            }
        }
    }

    private void PlayerOut(int loser)
    {
        score.players[0].SetActive(false);
        score.players[1].SetActive(false);
        score.players[0].transform.position = playerSpawns[0].transform.position;
        score.players[0].transform.rotation = Quaternion.identity;
        score.players[1].transform.position = playerSpawns[1].transform.position;
        score.players[1].transform.rotation = Quaternion.identity;
        score.LoseLife(loser, 1);
    }

    public void NextRound()
    {
        score.players[0].SetActive(true);
        score.players[1].SetActive(true);
        spawn.SpawnObjects();
        roundOverPanel.SetActive(false);
    }
}
