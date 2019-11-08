using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{

    public GameObject m_Taskmaster;

    void Start()
    {
        m_Taskmaster = GameObject.FindGameObjectWithTag("Taskmaster");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (m_Taskmaster.GetComponent<TaskmasterMovement>() != null)
                m_Taskmaster.GetComponent<TaskmasterMovement>().l_MoveAgain = true;
            else if (m_Taskmaster.GetComponent<TaskmasterMovement_PS>() != null)
                m_Taskmaster.GetComponent<TaskmasterMovement_PS>().l_MoveAgain = true;
            

        }
    }
}
