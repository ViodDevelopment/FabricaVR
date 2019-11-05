using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameObject m_Hornero;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            DestroyImmediate(this);
        }



    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    public void Update()
    {
        //if(m_Hornero.GetComponent<Animator>().GetBool("Hablando")&&!m_Hornero.GetComponent<AudioSource>().isPlaying)
        //{
        //    StopHornero();
        //}
    }

    public void HorneroTrigger()
    {
            m_Hornero.GetComponent<Animator>().SetBool("Hablando", true);
            m_Hornero.GetComponent<AudioSource>().Play();
    }

    public void StopHornero()
    {
        m_Hornero.GetComponent<Animator>().SetBool("Hablando", false);
    }
}
