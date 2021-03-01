using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO_Mario : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public float speed = 4.0f;
	
	void Update()
	{
		Jump();
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
	}
	
	void Jump(){
		if (Input.GetButtonDown("Jump")) 
		{
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
		}
		
    }
}
