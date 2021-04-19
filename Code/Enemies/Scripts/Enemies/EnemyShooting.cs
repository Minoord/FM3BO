using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public float maxHealth;
    private float curHealth;

    public GameObject Bullet;
    public float fireRate;
    public float range;
    public Rigidbody2D target;

    private float nextBullet;

    public Score score;

    void Start()
    {
        GameObject scoreObj = GameObject.Find("HighScoreText");
        score = scoreObj.GetComponent<Score>();
        curHealth = maxHealth;
        nextBullet = 0;
    }

    void Update()
    {
        Shoot();

        if (curHealth <= 0)
        {
            score.AddScoreDefeatNormalEnemie();
            Destroy(this.gameObject);
        }
    }

    void Shoot()
    {
        if (Vector2.Distance(target.position, transform.position) <= range)
        {
            if (nextBullet <= 0)
            {
                nextBullet = fireRate;
                Instantiate(Bullet, transform.position, Quaternion.identity);
            }
            else
            {
                nextBullet -= Time.deltaTime;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        Debug.Log("Damage");
    }
}
