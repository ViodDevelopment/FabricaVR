using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCubes : MonoBehaviour
{
    public GameObject[] m_CubesList;
    private GameObject m_Player;
    private int l_Cube = 0;

    public int l_ActionsCubes;

    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(m_Player.transform.position, m_CubesList[l_Cube].transform.position) < 1.5f)
        {
            l_ActionsCubes++;
            Destroy(m_CubesList[l_Cube]);
            l_Cube++;
            m_CubesList[l_Cube].SetActive(true);            
        }
    }
}
