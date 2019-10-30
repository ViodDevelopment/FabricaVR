using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HorneroAudio : MonoBehaviour
{
    public AudioClip[] m_Audio;
    private AudioSource m_Hornero_AS;
    private int m_ActualAudio = 0;
    private bool m_HorneroActive = false;

    void Start()
    {
        m_Hornero_AS = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (m_HorneroActive)
        {
            if (!m_Hornero_AS.isPlaying && m_Audio.Length > m_ActualAudio)
            {
                m_ActualAudio++;
                PlayAudios();
            }
        }
    }

    private void PlayAudios()
    {
        m_Hornero_AS.clip = m_Audio[m_ActualAudio];
        m_Hornero_AS.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayAudios();
            m_HorneroActive = true;
        }
    }
}
