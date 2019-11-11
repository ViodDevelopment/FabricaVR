using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaskmasterAudio_Fachada : MonoBehaviour
{
    private Animator m_Animator;
    public Image m_Image;
    public AudioClip[] m_Audio;
    private AudioSource m_Capataz_AS;
    public bool m_Movement = false;
    public bool m_Reproduce = false;public FadeIn player;
    public int m_AudiosPlayed = 0;

    void Start()
    {
        m_Capataz_AS = GetComponent<AudioSource>();
        m_Animator = transform.GetChild(0).GetComponent<Animator>();
        PlayAudio();
        m_AudiosPlayed++;
    }

    void Update()
    {
        m_Animator.SetLayerWeight(3, Mathf.Clamp(Mathf.Sin(Time.time), 0, 1));
        if (m_Capataz_AS.isPlaying)
            m_Animator.SetLayerWeight(1, 1);

        else
            m_Animator.SetLayerWeight(1, 0);
        
        if (m_Reproduce)
        {
            if (m_AudiosPlayed == 0)
            {

            }
            else if (!m_Capataz_AS.isPlaying && m_AudiosPlayed == 1)
            {
                PlayAudio();
                m_AudiosPlayed++;
            }
            else if (m_AudiosPlayed == 2)
            {
                if (m_Movement)
                {
                    PlayAudio();
                    m_AudiosPlayed++;
                    m_Reproduce = false;
                }
            }
            else if (m_AudiosPlayed == 3)
            {
                PlayAudio();
                m_AudiosPlayed++;
            }
            else if (m_AudiosPlayed == 4 && !m_Capataz_AS.isPlaying && m_Image != null)
            {
                if (!player.enabled)
                {
                    player.enabled = true;
                    player.switchInverso(true);
                }

                if (m_Image.color.a >= 0.9f)
                        SceneManager.LoadScene(5); 
            }
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
            m_Reproduce = true;
        }

        if(coll.name == "AudioCapataz")
        {
            m_Movement = true;
        }
    }
}
