using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCubes : MonoBehaviour
{
    public GameObject[] m_CubesList;
    private GameObject m_Player;
    private int l_Cube = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(m_Player.transform.position, m_CubesList[l_Cube].transform.position) < 1.5f)
        {
            Debug.Log("Changing " + l_Cube + " for " + l_Cube + 1);
            Destroy(m_CubesList[l_Cube]);
            l_Cube++;
            m_CubesList[l_Cube].SetActive(true);            
        }
    }
}
