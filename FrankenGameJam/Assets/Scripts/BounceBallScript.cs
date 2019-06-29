using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBallScript : MonoBehaviour
{
    public BallManagerScript managerScript;
    public int bounceCounter;
    public Coroutine bounceRoutine;

    private Rigidbody2D rbBounceBall;

    public void OnTriggerEnter2D(Collider2D col)
    {
        rbBounceBall = GetComponent<Rigidbody2D>();
        if (col.CompareTag("BallBorder") && bounceCounter < 2)
        {
            if(bounceRoutine == null)
            {
                bounceRoutine = StartCoroutine(RealBounce());
            }
        }
        if (col.CompareTag("BallBorder") && bounceCounter == 2)
        {
            managerScript.BallRemove(gameObject);
            Destroy(gameObject);
        }
        if (col.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Health>().Loosehealth();
            managerScript.BallRemove(gameObject);
            Destroy(gameObject);
        }
    }
   
    public IEnumerator RealBounce()
    {
        rbBounceBall.velocity = rbBounceBall.velocity * -1;
        bounceCounter++;
        yield return new WaitForSeconds(1);
        bounceRoutine = null;
    }
}
