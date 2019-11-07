using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCube : MonoBehaviour
{
    public float m_Speed = 0.75f;
    private bool m_Going = false;
    private GameObject m_Object;
    public CharacterController characterController;
    void FixedUpdate()
    {
        if (m_Going == true)
        {
            if (m_Object == null)
                StopGoingTo();
            else if (Vector3.Distance(this.transform.position, m_Object.transform.position) < 1.5f && this.tag == "Player" && m_Object.tag == "Taskmaster")
            {
                StopGoingTo();
            }

            else
            {
                if (characterController != null)
                {
                    characterController.Move(Camera.main.transform.forward * m_Speed * Time.deltaTime);
                }
                else
                    transform.position = transform.position + Camera.main.transform.forward * m_Speed * Time.deltaTime;
            }

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
