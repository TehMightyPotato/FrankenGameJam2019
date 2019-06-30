using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    private Playertype playertype;
    public int health;
    public int maxhealth;
    public CameraController camController;
    public AudioSource getHitSource;
    public MrTorgue mrtorgue;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        playertype = gameObject.GetComponent<Movement>().playertype;
    }

    // Update is called once per frame
    public void Loosehealth()
    {
        mrtorgue.PlayRandomHitClip();
        getHitSource.Play();
        camController.ScreenShake(0.25f, 100);
        health = health - 1;
        SpaceJimmy();
    }
    public void SpaceJimmy()
    {
        if (health > 0)
        {
            return;
        }

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