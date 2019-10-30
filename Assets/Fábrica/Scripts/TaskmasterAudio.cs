using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskmasterAudio : MonoBehaviour
{

    public AudioClip[] m_Audio;
    private AudioSource m_Capataz_AS;
    private int m_ActualAudio = 1;
    public bool m_Taquilla = false;
    public bool m_MasCarbon = false;
    public bool m_C_4_3 = false;
    public int m_AudiosPlayed = 0;

    void Start()
    {
        m_Capataz_AS = GetComponent<AudioSource>();
    }

    private void PlayAudio()
    {
        m_Capataz_AS.clip = m_Audio[m_ActualAudio-1];
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
                    if (m_Taquilla)
                    {
                        PlayAudio();
                        m_ActualAudio++;
                        m_AudiosPlayed++;
                    }
                    break;
                case 3:
                    PlayAudio();
                    m_ActualAudio++;
                    m_AudiosPlayed++;
                    break;
                case 4:
                    if (m_MasCarbon)
                    {
                        PlayAudio();
                        m_ActualAudio++;
                        m_AudiosPlayed++;
                    }
                    break;
                case 5:
                    PlayAudio();
                    m_ActualAudio++;
                    m_AudiosPlayed++;
                    break;
                case 6:
                    PlayAudio();
                    m_ActualAudio++;
                    m_AudiosPlayed++;
                    break;
                case 7:
                    if (m_C_4_3)
                    {
                        PlayAudio();
                        m_ActualAudio++;
                        m_AudiosPlayed++;
                    }
                    break;


            }
        }
    }
}
