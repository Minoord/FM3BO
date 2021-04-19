using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int HScore = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        HScore = Set.Instance.Highscore; 
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + HScore;
        SaveScore();
    }

    //Saving Score
    public void SaveScore()
    {
        Set.Instance.Highscore = HScore;

    }


    public void AddScoreDefeatMiniEnemie()
    {
        HScore += 5;
    }
    public void AddScoreDefeatNormalEnemie()
    {
        HScore += 10;
    }
    public void AddScoreDefeatBigEnemie()
    {
        HScore += 15;
    }
    public void AddScoreDefeatEndEnemie()
    {
        HScore += 30;
    }

    public void AddScorePickUpMiniCoin()
    {
        HScore += 5;
    }
    public void AddScorePickUpBigCoin()
    {
        HScore += 10;
    }

    public void MinusScoreDeath()
    {
        HScore -= 25;
    }
}