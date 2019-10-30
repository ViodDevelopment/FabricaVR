using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public bool m_MoveToNextPoint;
    public int l_ActiveCubes;
    public int l_Room;
    public GameObject m_Taskmaster;

    void Start()
    {
        //if(m_Scene = 0)
        //{
        //    l_Room = 0;
        //    l_ActiveCubes = 0;
        //}
        //if (m_Scene = 1)
        //{
            l_Room = 0;
            l_ActiveCubes = 0;
        //}
        //else
        //{
        //    l_Room = 4;
        //   l_ActiveCubes = 0;
        //}


    }

    void Update()
    {
        switch (l_Room)
        {
            case 0:
                m_MoveToNextPoint = true;
                l_Room++;
                break;
            case 1:
                if(l_ActiveCubes == 2 && m_Taskmaster.GetComponent<TaskmasterAudio>().m_AudiosPlayed == 2)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
                    l_Room++;
                }
                break;
            case 2:
                if (l_ActiveCubes == 1 && m_Taskmaster.GetComponent<TaskmasterAudio>().m_AudiosPlayed == 4)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
                    l_Room++;
                }
                break;
            case 3:
                if (l_ActiveCubes == 1)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
                    l_Room++;
                }
                break;
            case 4:
                if (l_ActiveCubes == 1 && m_Taskmaster.GetComponent<TaskmasterAudio>().m_AudiosPlayed == 6)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
                    l_Room++;
                }
                break;
            case 5:
                if (l_ActiveCubes == 1)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
                    l_Room++;
                }
                break;
            case 6:
                if (l_ActiveCubes == 2)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
                    l_Room++;
                }
                break;
            case 7:
                if (l_ActiveCubes == 2)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
                    l_Room++;
                }
                break;
            case 8:
                if (l_ActiveCubes == 4)
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
        if (other.tag == "C_4_3")
        {
            m_Taskmaster.GetComponent<TaskmasterAudio>().m_C_4_3 = true;
        }

    }
}
