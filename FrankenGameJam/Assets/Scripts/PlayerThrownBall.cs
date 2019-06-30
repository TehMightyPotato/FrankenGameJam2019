using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrownBall : GenericBall
{
    public Coroutine looseSpaceHealthRoutine;
    public GameObject origin;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("BallBorder"))
        {
            Destroy(gameObject);
        }
        if (col.CompareTag("Player") && col.gameObject != origin)
        {
            if (looseHealthRoutine == null)
            {
                looseHealthRoutine = StartCoroutine(LooseHealthRoutine(col.gameObject));
            }
        }
        if (col.CompareTag("Spaceghost"))
        {
            if(looseSpaceHealthRoutine == null)
            {
                looseSpaceHealthRoutine = StartCoroutine(LooseSpaceHealthRoutine(col.gameObject));
            }
        }
    }


    public new IEnumerator LooseHealthRoutine(GameObject player)
    {
        player.GetComponent<Health>().Loosehealth();
        yield return null;
        Destroy(gameObject);
    }
    public IEnumerator LooseSpaceHealthRoutine(GameObject spaceghost)
    {
        var ghostscript = spaceghost.GetComponent<SPACEGHOST>();
        ghostscript.LooseSpacehealth();
        yield return null;
        Destroy(gameObject);
    }
}
