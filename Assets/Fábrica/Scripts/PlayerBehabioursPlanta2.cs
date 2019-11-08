using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehabioursPlanta2 : MonoBehaviour
{
    public bool m_MoveToNextPoint;
    public int l_ActiveCubes = 0;
    public int l_Room = 0;
    public GameObject m_Taskmaster;
    public MozoDeAlmacen mozo;
    private bool almacen;
    private bool bajado;
    private float timer = 0;
    public Transform transformPlayerAlmacen;
    public Transform transformCapatazAlmacen;
    void Start()
    {
        m_MoveToNextPoint = true;
        almacen = false;
        bajado = false;
    }

    void Update()
    {
        switch (l_Room)
        {
            case 0:
                if (l_ActiveCubes == 1 && m_Taskmaster.GetComponent<TaskmasterAudio_PS>().m_AudiosPlayed == 2)
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
                    l_Room++;
                }
                break;
            case 1:
                if (m_Taskmaster.GetComponent<TaskmasterAudio_PS>().m_AudiosPlayed == 3 && (!m_Taskmaster.GetComponent<AudioSource>().isPlaying))
                {
                    m_MoveToNextPoint = true;
                    l_ActiveCubes = 0;
                    this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes = l_ActiveCubes;
                    l_Room++;
                }

                break;
            case 2:
                if (mozo.objetosQueActivas[1] == null)
                {
                    mozo.saco = true;
                    l_Room++;
                }

                break;
            case 3:

                break;
        }
        l_ActiveCubes = this.gameObject.GetComponent<ActivateCubes>().l_ActionsCubes;

        if (almacen && !gameObject.GetComponent<FadeIn>().enabled && !bajado)
        {
            m_MoveToNextPoint = true;
            gameObject.GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = transformPlayerAlmacen.position;
            m_Taskmaster.transform.position = transformCapatazAlmacen.position;
            gameObject.transform.forward = (new Vector3(m_Taskmaster.transform.position.x - gameObject.transform.position.x, 0, m_Taskmaster.transform.position.z - gameObject.transform.position.z)).normalized;
            bajado = true;
            gameObject.GetComponent<CharacterController>().enabled = true;
            gameObject.GetComponent<FadeIn>().enabled = true;
            gameObject.GetComponent<FadeIn>().speedToClear = 1.2f;
            gameObject.GetComponent<FadeIn>().switchInverso(false);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trigger_C_4_3")
        {
            m_Taskmaster.GetComponent<TaskmasterAudio_PS>().PlayNextAudio();
        }
        if (other.gameObject.name == "TriggerAlmacen2")
        {
            almacen = true;
            gameObject.GetComponent<FadeIn>().enabled = true;
            gameObject.GetComponent<FadeIn>().switchInverso(true);
            gameObject.GetComponent<FadeIn>().speedToClear = 1.2f;
            timer = 0.2f;
        }
    }
}


