using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagrDeTriggers : MonoBehaviour
{
    public List<AudioSource> audios =  new List<AudioSource>();
    public List<AudioSource> audiosVuelta = new List<AudioSource>();
    private bool firstTime = true;
    private bool acabado = false;
    private void PlayAllAudios(bool _ida)
    {
        if (_ida)
        {
            foreach (AudioSource item in audios)
            {
                item.Play();
            }
            firstTime = false;
            if (audiosVuelta.Count == 0)
                acabado = true;
        }
        else
        {
            foreach (AudioSource item in audiosVuelta)
            {
                item.Play();
            }
            acabado = true;
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            if (!acabado)
            {
                PlayAllAudios(firstTime);
            }
        }
    }
}
