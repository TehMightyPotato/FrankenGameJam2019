using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManagerScript : MonoBehaviour
{
    public List<GameObject> ballList = new List<GameObject>();
    public List<BallSpawnScript> spawnerList = new List<BallSpawnScript>();
    public float timeCounter;
    public float maxTimeCounter;
    public int maxBalls;
    public int deadBalls;

    // Start is called before the first frame update
    void Start()
    {
        var spawners = GameObject.FindGameObjectsWithTag("BallSpawner");
        foreach (var spawner in spawners)
        {
            spawnerList.Add(spawner.GetComponent<BallSpawnScript>());
        }
        timeCounter = 0;
        StartCoroutine(MainRoutine());
    }

    public void BallSpawn()
    {
        var rng = Random.Range(0, spawnerList.Count);
        ballList.Add(spawnerList[rng].SpawnBall(this));
    }

    public void BallRemove(GameObject ball)
    {
        if (ballList.Contains(ball))
        {
            ballList.Remove(ball);
            deadBalls++;
        }
    }

    public IEnumerator MainRoutine()
    { 
        yield return new WaitForSeconds(5);
        
        while (true)
        {
            if (!(ballList.Count >= maxBalls + deadBalls / 3))
            {
                timeCounter += Time.deltaTime;
                if (timeCounter >= maxTimeCounter)
                {
                    BallSpawn();
                    timeCounter = 0;
                }
            }
            yield return new WaitForEndOfFrame();
        }
        
    }
}
