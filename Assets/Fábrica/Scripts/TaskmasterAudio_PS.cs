using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskmasterAudio_PS : MonoBehaviour
{
    public AudioClip[] m_Audio;
    private AudioSource m_Capataz_AS;
    private Animator m_Animator;
    public FadeIn player;
    private int m_ActualAudio = 0;
    public int m_AudiosPlayed = 0;
    private float timer;
    public bool acabarEscena;
    private bool firstTime;

    void Start()
    {
        timer = 0.2f;
        m_Capataz_AS = GetComponent<AudioSource>();
        m_Animator = transform.GetChild(0).GetComponent<Animator>();
        acabarEscena = false;
        firstTime = true;
    }

    void Update()
    {
        m_Animator.SetLayerWeight(3, Mathf.Clamp(Mathf.Sin(Time.time), 0, 1));

        if (m_Capataz_AS.isPlaying)
        {
            m_Animator.SetLayerWeight(1, 1);
            if (m_ActualAudio == 2)
                m_Animator.SetLayerWeight(2, Mathf.Clamp(m_Animator.GetLayerWeight(2) + Time.deltaTime, 0, 1));
            
        }
        else
        {
            m_Animator.SetLayerWeight(2, Mathf.Clamp(m_Animator.GetLayerWeight(2) - Time.deltaTime, 0, 1));
            m_Animator.SetLayerWeight(1, 0);
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
                timer = 0;
        }
        if (acabarEscena && !firstTime)
        {
            if(!m_Capataz_AS.isPlaying && timer == 0)
            {
                player.switchInverso(true);
                player.speedToClear = 0.5f;
                timer = 10f;
            }
            if (timer >= 8f)
                SceneManager.LoadScene(7);
        }
        else
        {
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
                    if (timer == 0 && !m_Capataz_AS.isPlaying)
                    {
                        PlayNextAudio();
                    }
                    break;
                case 4:
                    if(acabarEscena && firstTime)
                    {
                        PlayNextAudio();
                        firstTime = false;
                    }

                    break;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(acabarEscena && firstTime)
        {
            if (other.gameObject.tag == "Player")
            {
                PlayNextAudio();
                firstTime = false;
            }
        }
    }
}
