using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskmasterAudio_PS : MonoBehaviour
{
    public AudioClip[] m_Audio;
    private AudioSource m_Capataz_AS;
    private int m_ActualAudio = 0;
    public int m_AudiosPlayed = 0;
    private float timer;

    void Start()
    {
        timer = 0.2f;
        m_Capataz_AS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
                timer = 0;
        }
        switch (m_ActualAudio)
        {
            case 0:
                if (!m_Capataz_AS.isPlaying && timer <= 0)
                {
                    PlayAudio();
                    m_ActualAudio++;
                    m_AudiosPlayed++;
                    timer = m_Capataz_AS.clip.length + 0.2f;
                }
                break;
            case 4:
                if (!m_Capataz_AS.isPlaying && timer <= 0 && m_Capataz_AS.GetComponent<TaskmasterMovement_PS>().numCubos == 1)
                {
                    m_Capataz_AS.GetComponent<TaskmasterMovement_PS>().cubosPlayer[m_Capataz_AS.GetComponent<TaskmasterMovement_PS>().numCubos].SetActive(true);
                    m_Capataz_AS.GetComponent<TaskmasterMovement_PS>().numCubos++;
                }
                break;
        }
    }

    public void PlayNextAudio()
    {
        PlayAudio();
        m_ActualAudio++;
        m_AudiosPlayed++;
        timer = m_Capataz_AS.clip.length + 0.2f;
        if (m_ActualAudio == 3)
            timer += 5;
    }

    private void PlayAudio()
    {
        if (m_Audio.Length > m_ActualAudio)
        {
            m_Capataz_AS.clip = m_Audio[m_ActualAudio];
            m_Capataz_AS.Play();
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            switch (m_ActualAudio)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:
                    if (timer == 0)
                    {
                        PlayNextAudio();
                    }
                    break;
                case 4:

                    break;
            }
        }
    }
}
