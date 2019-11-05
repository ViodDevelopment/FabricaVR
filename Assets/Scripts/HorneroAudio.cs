using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HorneroAudio : MonoBehaviour
{
    public Image image;
    public AudioClip[] m_Audio;
    private AudioSource m_Hornero_AS;
    private int m_ActualAudio = 0;
    private bool m_HorneroActive = false;
    private bool acabado = false;

    public Animator m_Animator;

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
                PlayAudios();
                m_ActualAudio++;
            }
            else if(m_Audio.Length <= m_ActualAudio && !m_Hornero_AS.isPlaying)
            {
                m_Animator.SetBool("Girar", false);
                m_Animator.SetBool("Palea", true);
                m_HorneroActive = false;
                acabado = true;
            }
        }
        else if(acabado && image != null)
        {
            image.gameObject.SetActive(true);
            image.color = image.color + new Color(0, 0, 0, Time.deltaTime * 0.5f);
            if (image.color.a >= 0.9f)
                SceneManager.LoadScene(6); //cambiar depende de tio o tia
            
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
            if (!m_Hornero_AS.isPlaying && m_Audio.Length > m_ActualAudio && !m_HorneroActive)
            {
                m_Animator.SetBool("Palea", false);
                m_Animator.SetBool("Girar", true);
                m_HorneroActive = true;
            }
        }
    }
}
