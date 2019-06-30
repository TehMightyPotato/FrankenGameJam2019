using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGhostSpawner : MonoBehaviour
{
    [SerializeField]
    private int maxCatchesNeeded;
    [SerializeField]
    private int player1CatchCount;
    [SerializeField]
    private int player2CatchCount;
    [SerializeField]
    private bool spaceGhostSpawned;
    [SerializeField]
    private GameObject spaceGhost;
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private CameraController camController;
    public MrTorgue mrtorgue;


    private void Start()
    {
        player1.GetComponent<Movement>().caughtBall += OnPlayer1Caught;
        player2.GetComponent<Movement>().caughtBall += OnPlayer2Caught;

    }
    public void OnPlayer1Caught(object sender, EventArgs e)
    {
        player1CatchCount += 1;
        CheckForSpawn();
    }

    public void OnPlayer2Caught(object sender, EventArgs e)
    {
        player2CatchCount += 1;
        CheckForSpawn();
    }

    public void CheckForSpawn()
    {
        if(player1CatchCount >= maxCatchesNeeded && player2CatchCount >= maxCatchesNeeded && !spaceGhostSpawned)
        {
            spaceGhostSpawned = true;

            StartCoroutine(SpawnSpaceGhost());
        }
    }

    public IEnumerator SpawnSpaceGhost()
    {
        while (mrtorgue.ownAudioSource.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        camController.ScreenShake(0.25f, 100);
        spaceGhost.SetActive(true);
        mrtorgue.tutorialRunning = true;
        mrtorgue.PlaySpaceGhostIntro();
        while (mrtorgue.ownAudioSource.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
       
        yield return null;
    }
}
