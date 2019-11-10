﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskmasterAudio : MonoBehaviour
{
    private Animator m_Animator;
    public AudioClip[] m_Audio;
    private AudioSource m_Capataz_AS;
    private int m_ActualAudio = 1;
    public bool m_Taquilla = false;
    public bool m_MasCarbon = false;
    public bool m_CarbonInfo = false;
    public int m_AudiosPlayed = 0;

    void Start()
    {
        m_Animator = transform.GetChild(0).GetComponent<Animator>();

        m_Capataz_AS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        m_Animator.SetLayerWeight(3, Mathf.Clamp(Mathf.Sin(Time.time), 0, 1));

        if (m_Capataz_AS.isPlaying)
        {
            m_Animator.SetLayerWeight(1, 1);

            if (m_ActualAudio==2 || m_ActualAudio == 5)
            {
                m_Animator.SetLayerWeight(2, Mathf.Clamp(m_Animator.GetLayerWeight(2) + Time.deltaTime, 0, 1));

            }
        }
        else
        {
            m_Animator.SetLayerWeight(2, Mathf.Clamp(m_Animator.GetLayerWeight(2) - Time.deltaTime, 0, 1));
            m_Animator.SetLayerWeight(1, 0);
        }
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
                    coll.gameObject.GetComponent<ActivateCubes>().m_CubesList[coll.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes].SetActive(true);
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
                    if(m_CarbonInfo)
                    {
                        PlayAudio();
                        m_ActualAudio++;
                        m_AudiosPlayed++;
                    }
                    break;
                case 4:
                    if (m_MasCarbon)
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
