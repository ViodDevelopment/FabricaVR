using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehabioursPlanta2 : MonoBehaviour
{
    public bool m_MoveToNextPoint;
    public int l_ActiveCubes = 0;
    public int l_Room = 0;
    public GameObject m_Taskmaster;

    void Start()
    {
        m_MoveToNextPoint = true;
    }

    void Update()
    {
        switch (l_Room)
        {
            case 0:
                if (l_ActiveCubes == 1 && m_Taskmaster.GetComponent<TaskmasterAudio_PS>().m_AudiosPlayed == 2)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
                    l_Room++;
                }
                break;
            case 1:
                if (m_Taskmaster.GetComponent<TaskmasterAudio_PS>().m_AudiosPlayed == 3 && (!m_Taskmaster.GetComponent<AudioSource>().isPlaying))
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
                    l_Room++;
                }

                break;
            case 2:

                break;
            case 3:

                break;
        }
        l_ActiveCubes = this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Trigger_C_4_3")
        {
            m_Taskmaster.GetComponent<TaskmasterAudio_PS>().PlayNextAudio();
        }
        if (other.gameObject.name == "TriggerAlmacen2")
        {

        }
    }
}


