using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCube : MonoBehaviour
{
    public float m_Speed = 1;
    private bool m_Going = false;
    private GameObject m_Object;

    void FixedUpdate()
    {
        if (m_Going == true)
        {
            if (Vector3.Distance(this.transform.position, m_Object.transform.position) < 1f && this.tag == "Player" && m_Object.tag == "Taskmaster")
            {
                StopGoingTo();
            }
            else
                transform.position = transform.position + Camera.main.transform.forward * m_Speed * Time.deltaTime;

            if (m_Object == null)
                StopGoingTo();
        }
        else
        {
            StopGoingTo();
        }
    }

    public void GoingTo(GameObject l_Object)
    {
        m_Object = l_Object;
        m_Going = true;
    }

    public void StopGoingTo()
    {
        m_Going = false;
    }
}
