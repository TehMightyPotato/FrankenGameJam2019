using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPUNCHIT : MonoBehaviour
{
	public float bounce;
	//public CircleCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
	    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			var otherpos = collision.gameObject.transform.position;
			var mypos = gameObject.transform.position;
			collision.gameObject.GetComponent<Rigidbody2D>().velocity = (otherpos - mypos) * bounce;
		}
	}
}
