using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagonetaMovement : MonoBehaviour
{
    public GameObject[] m_Points;
    private int m_ActualPoint = 0;
    private float m_Speed = 1f;
    private bool m_StartMoving = false;

    void Update()
    {
        if (m_Points.Length > m_ActualPoint)
        {
            if ((transform.position - m_Points[m_ActualPoint].transform.position).magnitude < 0.1f)
            {
                m_ActualPoint++;
            }
            else if (m_StartMoving)
            {
                Move();
            }
        }
        else
        {
            foreach(Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, m_Points[m_ActualPoint].transform.position, m_Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            m_StartMoving = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_StartMoving = false;
        }
    }
}
