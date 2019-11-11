using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCubes : MonoBehaviour
{
    public GameObject[] m_CubesList;
    private GameObject m_Player;
    private int l_Cube = 0;
    public GameObject CuboAceite;
    public GameObject CuboPalanca;
    public GameObject CuboTelar;
    public Animation AceiteAnimation;
    public Animation PalancaAnimation;
    public Animator TelarAnimatior;
    private PlayerBehabioursPlanta2 pbP2;
    private PlayerBehaviour pb;
    private bool animationAceiteDone;

    public int l_ActionsCubes;

    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        pb = m_Player.GetComponent<PlayerBehaviour>();
        pbP2 = m_Player.GetComponent<PlayerBehabioursPlanta2>();
        animationAceiteDone = false;

    }

    void Update()
    {
        if (l_Cube < m_CubesList.Length && m_CubesList[l_Cube] != null)
        {
            if (pbP2 == null || l_Cube != m_CubesList.Length - 1)
            {
                float distance;
                if (m_CubesList[l_Cube].transform.localScale.x < 0.5f)
                {
                    distance = 1.1f;
                }
                else
                    distance = m_CubesList[l_Cube].transform.localScale.x / 2 - 0.25f;


                if (Vector3.Distance(m_Player.transform.position, m_CubesList[l_Cube].transform.position) < distance && m_CubesList[l_Cube].activeSelf)
                {
                    Destroy(m_CubesList[l_Cube]);
                    l_ActionsCubes++;
                    l_Cube++;
                    if (l_Cube < m_CubesList.Length)
                    {
                        if (pb != null)
                            m_CubesList[l_Cube].SetActive(true);
                        else
                        {
                            if (CuboAceite == null && AceiteAnimation != null && !animationAceiteDone)
                            {
                                AceiteAnimation.Play();
                                animationAceiteDone = true;
                            }
                        }
                    }
                }
            }
        }
        if (pbP2 != null)
        {
            if (CuboAceite == null && AceiteAnimation != null && !animationAceiteDone)
            {
                AceiteAnimation.Play();
                animationAceiteDone = true;
            }
            if (CuboPalanca == null && PalancaAnimation != null)
            {
                PalancaAnimation.Play();
            }
            if (CuboTelar == null && PalancaAnimation != null && TelarAnimatior != null)
            {
                TelarAnimatior.SetBool("Telar", true);
            }
        }
    }
}
