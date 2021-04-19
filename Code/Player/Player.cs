using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	//Movement
	public float speed = 1.0f;
	public float JumpForce = 4.0f;

	//Health
	public float maxHealth = 5; 
	public static float curHealth;

	//score
	public Score score;

	//attack
	public float startTimeBtwAttack;
	public Transform attackPos;
	public Transform attackPosL;
	public Transform attackPosR;
	public float attackRange;
	public LayerMask whatIsEnemies;
	public int damage; 
	private float timeBtwAttack;

	private Rigidbody2D _rigidbody;
	
	// Start is called before the first frame update
	void Start()
    {
		GameObject scoreObj = GameObject.Find("HighScoreText");
		score = scoreObj.GetComponent<Score>();
		_rigidbody = GetComponent<Rigidbody2D>(); 
		curHealth = maxHealth;
    }

	void Update()
	{
		//Health
		if (curHealth <= 0)
		{
			transform.position = new Vector3( -7, -2, -4);
			curHealth = maxHealth;
			score.MinusScoreDeath();
		}

		// Walk 
		if (Input.GetKey("d"))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
			attackPos = attackPosR;
		}
		if (Input.GetKey("a"))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
			attackPos = attackPosL; 
		}
		//Jump
		if (Input.GetKey("w") && Mathf.Abs(_rigidbody.velocity.y) <0.001f)
        {
			_rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
		//Attack
		if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
			{
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
					
					SlimeEnemyMovement Senemy = enemiesToDamage[i].GetComponent<SlimeEnemyMovement>();
					if(Senemy != null)
                    {
						Senemy.TakeDamage(damage);
                    }
					
					EnemyShooting Eenemy = enemiesToDamage[i].GetComponent<EnemyShooting>();
					if (Eenemy != null)
					{
						Eenemy.TakeDamage(damage);
					}
					
					ShootingBoss Benemy = enemiesToDamage[i].GetComponent<ShootingBoss>();
					if (Benemy != null)
					{
						Benemy.TakeDamage(damage);
					}
				}
            }
			timeBtwAttack = startTimeBtwAttack;

        }
        else
        {
			timeBtwAttack -= Time.deltaTime;
        }
	}
	
	void OnDrawGizmosSelected()
    {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

	//damage
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			curHealth -= 1;
			Debug.Log("Hurt");
			if (attackPos == attackPosR)
            {
				transform.position += new Vector3(-1, 0, 0);
			}
			if (attackPos == attackPosL)
			{
				transform.position += new Vector3(1, 0, 0);
			}
			 
		}
		if (col.gameObject.tag == "Lava")
        {
			curHealth = maxHealth;
			transform.position = new Vector3(-7, -2, -4);
			score.MinusScoreDeath();
		}
	}

	void OnTriggerEnter2D(Collider2D trigger)
    {
		if (trigger.gameObject.tag == "Enemy")
        {
			curHealth -= 1;
			Debug.Log("Hurt");
			if (attackPos == attackPosR)
			{
				transform.position += new Vector3(-1, 0, 0);
			}
			if (attackPos == attackPosL)
			{
				transform.position += new Vector3(1, 0, 0);
			}
		}

    }
}
