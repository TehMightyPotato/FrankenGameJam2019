using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxhealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    public void Loosehealth()
    {
        health = health - 1;
        Jimmy();
    }
    public void Jimmy()
    {
        if (health > 0)
        {
            Debug.Log("yeah you're alive!");
        }
        Debug.Log("OH MY GOD, SHE FUCKING DEAD!");
        
    }
}