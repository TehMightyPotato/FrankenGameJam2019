using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public BallManagerScript managerScript;

    public void HitPlayer()
    {
        
    }

    public void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "BallBorder")
        {
            managerScript.BallRemove(gameObject);
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
