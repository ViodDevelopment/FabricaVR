using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFachada : MonoBehaviour
{
    public bool m_MoveToNextPoint;
    public int l_ActiveCubes = 0;
    public int l_Room = 0;
    public GameObject m_Taskmaster;

    void Update()
    {
        switch (l_Room)
        {
            case 0:
                if (m_Taskmaster.GetComponent<TaskmasterAudio_Fachada>().m_AudiosPlayed == 2 && !m_Taskmaster.GetComponent<AudioSource>().isPlaying)
                {
                    m_MoveToNextPoint = true;
                    l_Room++;
                }
                break;
            case 1:
                if (m_Taskmaster.GetComponent<TaskmasterAudio_Fachada>().m_AudiosPlayed == 3)
                {
                    m_MoveToNextPoint = true;
                    l_Room++;
                }
                break;
        }
    }
}
