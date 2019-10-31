using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoAlice : MonoBehaviour
{
    public List<GameObject> points = new List<GameObject>();
    public Alice alice;
    public List<AudioClip> clips = new List<AudioClip>();
    public AudioSource audioCapataz;
    public AudioSource audioAlice;
    private float currentTime = 0;
    private int currentClip = 0;
    public bool acabado = false;

    void Update()
    {
        if (!acabado)
        {
            if (points[0] == null && currentClip == 0)
            {
                audioCapataz.clip = clips[currentClip];
                audioCapataz.Play();
                currentClip++;
            }

            if (points[1] == null && !audioCapataz.isPlaying && currentClip == 1)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= 0.1f)
                {
                    currentTime = 0;
                    audioCapataz.clip = clips[currentClip];
                    audioCapataz.Play();
                    currentClip++;
                }
            }

            if (currentClip == 2 && !audioCapataz.isPlaying && !alice.action)
                alice.action = true;

            if (currentClip == 2 && alice.finish)
            {
                audioAlice.clip = clips[currentClip];
                audioAlice.Play();
                currentClip++;
            }

            if (currentClip == 3 && !audioAlice.isPlaying)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= 0.1f)
                {
                    currentTime = 0;
                    audioCapataz.clip = clips[currentClip];
                    audioCapataz.Play();
                    currentClip++;
                }
            }

            if (currentClip == 4 && !audioCapataz.isPlaying)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= 0.1f)
                {
                    currentTime = 0;
                    audioAlice.clip = clips[currentClip];
                    audioAlice.Play();
                    currentClip++;
                }
            }

            if (currentClip == 5 && !audioAlice.isPlaying)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= 0.1f)
                {
                    currentTime = 0;
                    audioCapataz.clip = clips[currentClip];
                    audioCapataz.Play();
                    currentClip++;
                }
            }

            if (currentClip == 6 && !audioCapataz.isPlaying)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= 12f)
                {
                    currentTime = 0;
                    audioAlice.clip = clips[currentClip];
                    audioAlice.Play();
                    currentClip++;
                }
            }

            if (currentClip == 7 && !audioAlice.isPlaying)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= 0.1f)
                {
                    currentTime = 0;
                    audioCapataz.clip = clips[currentClip];
                    audioCapataz.Play();
                    acabado = true;
                }
            }
        }
    }
}
