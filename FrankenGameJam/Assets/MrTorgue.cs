using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrTorgue : MonoBehaviour
{
    public bool tutorialRunning = true;
    public BallManagerScript ballManagerScript;
    public List<AudioClip> hitClipList = new List<AudioClip>();
    public AudioSource ownAudioSource;
    public AudioClip introclip;
    public AudioClip beginclip;
    public AudioClip leftbumper;
    public AudioClip rightbumper;
    public AudioClip spaceGhost;
    public AudioSource musicsource;

    private void Start()
    {
        StartCoroutine(GameStartRoutine());
    }

    public void PlayRandomHitClip()
    {
        if (tutorialRunning) return;
        var rng = UnityEngine.Random.Range(0,hitClipList.Count);
        if (ownAudioSource.isPlaying) return;
        ownAudioSource.clip = hitClipList[rng];
        ownAudioSource.Play();
    }
    public void PlaySpaceGhostIntro()
    {
        ownAudioSource.clip = spaceGhost;
        ownAudioSource.Play();
    }

    public IEnumerator GameStartRoutine()
    {
        ownAudioSource.clip = introclip;
        ownAudioSource.Play();
        while (ownAudioSource.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(4);
        ownAudioSource.clip = beginclip;
        ownAudioSource.Play();
        while (ownAudioSource.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        ballManagerScript.StartMainRoutine();
        musicsource.Play();
        yield return new WaitForSeconds(4);
        ownAudioSource.clip = leftbumper;
        ownAudioSource.Play();
        while (ownAudioSource.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(4);
        ownAudioSource.clip = rightbumper;
        ownAudioSource.Play();
        while (ownAudioSource.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }
        tutorialRunning = false;
    }
}
