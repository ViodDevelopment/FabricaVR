using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskmasterMovement : MonoBehaviour
{

    public GameObject[] m_MovePoints;
    private int m_ActiveMovingPoint;
    private int l_Point;

    private float m_Speed;
    private float l_MovingCounter;

    private GameObject m_Player;

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        l_Point = 0;
        m_Speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_Player.GetComponent<PlayerBehaviour>().m_MoveToNextPoint)
        {
            MoveTaskmaster();
        }

        if (Vector3.Distance(this.transform.position, m_MovePoints[l_Point].transform.position) < 1f)
        {
            if (m_MovePoints[l_Point].tag == "Moving" && l_MovingCounter >= 4)
            {
                l_Point++;
                l_MovingCounter = 0;
            }
            else if (m_MovePoints[l_Point].tag == "Waiting")
            {
                l_Point++;
                m_Player.GetComponent<PlayerBehaviour>().m_MoveToNextPoint = false;
            }
            else
                l_MovingCounter += Time.deltaTime;
        }

        

    }

    public void MoveTaskmaster()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, m_MovePoints[l_Point].transform.position, m_Speed * Time.deltaTime);
    }
}
