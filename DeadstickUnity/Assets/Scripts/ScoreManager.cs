using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector]
    public List<Score> scoresThisGame;
    [HideInInspector]
    public List<Score> scoresAllTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //add a score object to scoresThisGame
    public void AddScore(Score s)
    {
        scoresThisGame.Add(s);
        scoresThisGame.Sort(Score.CompareScores);
        scoresAllTime.Add(s);
        scoresAllTime.Sort(Score.CompareScores);
        Debug.Log("Score added, time: " + s.time);
    }

    public void SaveScores()
    {

    }

    public void LoadScores()
    {

    }

    public Score GetScore(bool allTime, int i)
    {
        if (allTime)
        {
            if (i < scoresAllTime.Count)
            {
                return scoresAllTime[i];
            }
        }
        else
        {
            if (i < scoresThisGame.Count)
            {
                return scoresThisGame[i];
            }
        }
        return null;
    }
}
