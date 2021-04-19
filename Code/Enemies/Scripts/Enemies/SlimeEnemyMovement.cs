using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemyMovement : MonoBehaviour
{
    public float JumpForce;
    public float JumpTime;

    public float maxHealth;
    private float curHealth;

    private float CurTime;
    private int JumpDirection;
    private Rigidbody2D _rigidbody;
    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreObj = GameObject.Find("HighScoreText");
        score = scoreObj.GetComponent<Score>();
        curHealth = maxHealth;
        CurTime = 0;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpingSlime();

        if (curHealth <= 0)
        {
            score.AddScoreDefeatMiniEnemie();
            Destroy(this.gameObject);
        }
    }

    void JumpingSlime()
    {
        JumpDirection = Random.Range(1, 3);

        if (CurTime <= 0)
        {
            CurTime = JumpTime;
            if (JumpDirection == 1)
            {
                _rigidbody.AddForce(new Vector2(JumpForce, JumpForce*2), ForceMode2D.Impulse);
                JumpDirection = Random.Range(1, 3);
            }
            if (JumpDirection == 2)
            {
                _rigidbody.AddForce(new Vector2(-JumpForce, JumpForce*2), ForceMode2D.Impulse);
                JumpDirection = Random.Range(1, 3);
            }
        }
        else
        {
            CurTime -= Time.deltaTime;
        }

    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        Debug.Log("Damage");
    }
}
