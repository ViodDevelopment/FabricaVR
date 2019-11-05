using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
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
                m_MoveToNextPoint = true;
                l_Room++;
                break;
            case 1:
                if(l_ActiveCubes == 1 && m_Taskmaster.GetComponent<TaskmasterAudio>().m_AudiosPlayed == 2)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
                    l_Room++;
                }
                break;
            case 2:
                if(m_Taskmaster.GetComponent<TaskmasterAudio>().m_AudiosPlayed == 3)
                {
                    m_MoveToNextPoint = true;
                    l_Room++;
                }
                break;
            case 3:
                if (l_ActiveCubes == 1 && m_Taskmaster.GetComponent<TaskmasterAudio>().m_AudiosPlayed == 4)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
                    l_Room++;
                }
                break;
        }
        l_ActiveCubes = this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Taquilla")
        {
            m_Taskmaster.GetComponent<TaskmasterAudio>().m_Taquilla = true;
        }
        if (other.tag == "MasCarbon")
        {
            m_Taskmaster.GetComponent<TaskmasterAudio>().m_MasCarbon = true;
        }
        if (other.name == "TriggerCansado")
        {
            m_Taskmaster.GetComponent<TaskmasterAudio>().m_CarbonInfo = true;
        }
    }
}
