using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{

    GameObject m_Taskmaster;

    void Start()
    {
        m_Taskmaster = GameObject.FindGameObjectWithTag("Taskmaster");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            m_Taskmaster.GetComponent<TaskmasterMovement>().l_MoveAgain = true;
        }
    }
}
