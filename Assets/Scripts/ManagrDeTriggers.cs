using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagrDeTriggers : MonoBehaviour
{
    public List<AudioSource> audios =  new List<AudioSource>();
    private bool firstTime = true;
    private void PlayAllAudios()
    {
        foreach (AudioSource item in audios)
        {
            item.Play();
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            if (firstTime)
            {
                firstTime = false;
                PlayAllAudios();
            }
        }
    }
}
