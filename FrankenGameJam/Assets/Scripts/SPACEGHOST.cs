using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPACEGHOST : MonoBehaviour
{
	public GameObject waypointL;
	public GameObject waypointR;
	public Rigidbody2D rb;
	public Coroutine timeroutine;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine(Timeroutine());
	}

	// Update is called once per frame
	void Update()
	{

	}

    void FixedUpdate()
	{
		if (transform.position.x >= waypointR.transform.position.x)
		{
			rb.velocity = rb.velocity * -1;
		}
		if (transform.position.x <= waypointL.transform.position.x)
		{
			rb.velocity = rb.velocity * -1;
		}
	}
		public IEnumerator Timeroutine()
	{
		yield return new WaitForSeconds(3);
		rb.velocity = new Vector2(2,0);
	}
 
}