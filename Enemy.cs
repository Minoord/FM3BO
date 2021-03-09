using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed;
    public float maxHealth;
    float curHealth;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);

        if (curHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        Debug.Log("Damage");
    }

} 