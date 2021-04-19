using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public float moveSpeed;
    public float maxHealth;
    private float curHealth;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);

        if (curHealth <= 0)
        {
            GetComponent<Renderer>().enabled = false;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            moveSpeed *= -1;
        }
    }
    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        Debug.Log("Damage");
    }
}
