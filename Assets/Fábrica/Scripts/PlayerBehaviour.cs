using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public bool m_MoveToNextPoint;
    public int l_ActiveCubes;
    public int l_Room;

    void Start()
    {
        l_Room = 1;
        l_ActiveCubes = 0;
    }

    void Update()
    {
        switch (l_Room)
        {
            case 1:
                if(l_ActiveCubes == 1)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    l_Room++;
                }
                break;
            case 2:
                if (l_ActiveCubes == 3)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    l_Room++;
                }
                break;
            case 3:
                if (l_ActiveCubes == 1)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    l_Room++;
                }
                break;
            case 4:
                if (l_ActiveCubes == 2)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    l_Room++;
                }
                break;
            case 5:
                if (l_ActiveCubes == 1)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    l_Room++;
                }
                break;
            case 6:
                if (l_ActiveCubes == 2)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    l_Room++;
                }
                break;
            case 7:
                if (l_ActiveCubes == 2)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    l_Room++;
                }
                break;
            case 8:
                if (l_ActiveCubes == 4)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    l_Room++;
                }
                break;
        }

        l_ActiveCubes = this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes;
        this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
    }
}
