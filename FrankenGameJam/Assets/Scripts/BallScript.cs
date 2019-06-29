using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public BallManagerScript managerScript;
    public Coroutine looseHealthRoutine;


    public void OnTriggerEnter2D (Collider2D col)
    {
        if(col.CompareTag("BallBorder"))
        {
            managerScript.BallRemove(gameObject);
            Destroy(gameObject);
        }
        if (col.CompareTag("Player"))
        {
            if(looseHealthRoutine == null)
            {
                looseHealthRoutine = StartCoroutine(LooseHealthRoutine(col.gameObject.GetComponent<Health>()));
            }
            managerScript.BallRemove(gameObject);
            Destroy(gameObject);
        }
    }
    
    public IEnumerator LooseHealthRoutine(Health health)
    {
        health.Loosehealth();
        yield return null;
    }
}
