using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCoin : MonoBehaviour
{
    public Score score;
    void Start()
    {
        GameObject scoreObj = GameObject.Find("HighScoreText");
        score = scoreObj.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            score.AddScorePickUpBigCoin();
        }

    }
}
