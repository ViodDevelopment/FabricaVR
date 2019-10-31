using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskmasterAudio_PS : MonoBehaviour
{
    public AudioClip[] m_Audio;
    private AudioSource m_Capataz_AS;
    private int m_ActualAudio = 1;
    public int m_AudiosPlayed = 0;

    void Start()
    {
        m_Capataz_AS = GetComponent<AudioSource>();
    }

    private void PlayAudio()
    {
        m_Capataz_AS.clip = m_Audio[m_AudiosPlayed];
        m_Capataz_AS.Play();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            switch (m_ActualAudio)
            {
                case 1:
                    PlayAudio();
                    m_ActualAudio++;
                    m_AudiosPlayed++;
                    break;
                case 2:
                        PlayAudio();
                        m_ActualAudio++;
                        m_AudiosPlayed++;
                    break;
                case 3:
                    PlayAudio();
                    m_ActualAudio++;
                    m_AudiosPlayed++;
                    break;
                case 4:

                        PlayAudio();
                        m_ActualAudio++;
                        m_AudiosPlayed++;

                    break;
            }
        }
    }
}
