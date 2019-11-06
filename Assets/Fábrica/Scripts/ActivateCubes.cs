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
        if (l_Cube < m_CubesList.Length && m_CubesList[l_Cube] != null)
        {
            if (Vector3.Distance(m_Player.transform.position, m_CubesList[l_Cube].transform.position) < 0.9f && m_CubesList[l_Cube].active)
            {
                Destroy(m_CubesList[l_Cube]);
                l_ActionsCubes++;
                l_Cube++;
                if (l_Cube < m_CubesList.Length)
                {
                    if(m_Player.GetComponent<PlayerBehaviour>() != null)
                        m_CubesList[l_Cube].SetActive(true);
                }
            }
        }
    }
}
