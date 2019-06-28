using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public BallManagerScript managerScript;

    public void OnTriggerEnter2D (Collider2D col)
    {
        if(col.CompareTag("BallBorder"))
        {
            managerScript.BallRemove(gameObject);
            Destroy(gameObject);
        }
        if (col.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Health>().Loosehealth();
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
