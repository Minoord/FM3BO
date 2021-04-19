using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDuration;
    Player target;

    private Rigidbody2D _rigidbody;
    private Vector2 bulletDirection;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        bulletDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        _rigidbody.velocity = new Vector2 (bulletDirection.x, bulletDirection.y);
        Destroy(this.gameObject, bulletDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            Debug.Log("Hit!");
            Destroy(this.gameObject);
        }
    }
}
