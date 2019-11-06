using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskmasterMovement_Fachada : MonoBehaviour
{
    public GameObject[] m_MovePoints;
    public int l_Point;

    private float m_Speed;
    public float l_MovingCounter;

    private GameObject m_Player;

    public Animator m_Animator;

    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        l_Point = 0;
        m_Speed = 0.6f;
        l_MovingCounter = 0;
    }

    void Update()
    {
        this.gameObject.transform.LookAt(new Vector3(m_Player.transform.position.x, gameObject.transform.position.y, m_Player.transform.position.z));

        if (m_Player.GetComponent<PlayerFachada>().m_MoveToNextPoint)
        {
            if (m_MovePoints.Length > l_Point)
            {
                MoveTaskmaster();
            }
        }
        else
            m_Animator.SetBool("Mover", false);

        if (m_MovePoints.Length > l_Point)
        {
            if (Vector3.Distance(this.transform.position, m_MovePoints[l_Point].transform.position) < 1f)
            {
                if (m_MovePoints[l_Point].tag == "Moving" && l_MovingCounter >= 4)
                {
                    l_Point++;
                    l_MovingCounter = 0;
                    m_Player.GetComponent<PlayerFachada>().m_MoveToNextPoint = true;

                }
                else if (m_MovePoints[l_Point].tag == "Waiting")
                {
                    l_Point++;
                    m_Player.GetComponent<PlayerFachada>().m_MoveToNextPoint = false;
                    m_Animator.SetBool("Mover", false);
                }
                else
                {
                    m_Player.GetComponent<PlayerFachada>().m_MoveToNextPoint = false;
                    m_Animator.SetBool("Mover", false);
                    l_MovingCounter += Time.deltaTime;
                }
            }
        }
    }

    public void MoveTaskmaster()
    {
        this.gameObject.transform.LookAt(m_MovePoints[l_Point].transform);

                    transform.position = Vector3.MoveTowards(this.transform.position, m_MovePoints[l_Point].transform.position, m_Speed * Time.deltaTime);
                    m_Animator.SetBool("Mover", true);

    }
}
