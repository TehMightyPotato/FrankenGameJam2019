using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBallScript : GenericBall
{
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
                return;
            }
        }
        if (col.CompareTag("BallBorder") && bounceCounter == 2)
        {
            Destroy(gameObject);
        }
        if (col.CompareTag("Player"))
        {
            if (looseHealthRoutine == null)
            {
                looseHealthRoutine = StartCoroutine(LooseHealthRoutine(col.gameObject));
            }
        }
        managerScript.BallRemove(gameObject);
    }

    public IEnumerator RealBounce()
    {
        rbBounceBall.velocity = rbBounceBall.velocity * -1;
        bounceCounter++;
        yield return new WaitForSeconds(1);
        bounceRoutine = null;
    }
}
