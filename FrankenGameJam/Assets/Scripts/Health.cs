using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    private Playertype playertype;
    public int health;
    public int maxhealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        playertype = gameObject.GetComponent<Movement>().playertype;
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
            return;
        }
        
        Debug.Log("OH MY GOD, SHE FUCKING DEAD!");

        if (playertype == Playertype.PLAYER1)
        {
            SceneManager.LoadScene("P2WINS");
        }
        if (playertype == Playertype.PLAYER2)
        {
            SceneManager.LoadScene("P1WINS");
        }
    }
}