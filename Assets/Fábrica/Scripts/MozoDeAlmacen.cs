﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MozoDeAlmacen : MonoBehaviour
{
    public bool empieza;
    public List<AudioClip> audiosMozo = new List<AudioClip>();
    private int currentAudio;
    public AudioSource audioSource;
    public List<GameObject> objetosQueActivas = new List<GameObject>();
    public PlayerBehabioursPlanta2 player;
    private int currentObjetosAActivar;
    private int pasos;
    public GameObject transformMozo;
    public GameObject capataz;
    public bool mapa;
    public bool saco;

    // Start is called before the first frame update
    void Start()
    {
        empieza = false;
        saco = false;
        mapa = false;
        currentAudio = 0; 
        currentObjetosAActivar = 0;
        pasos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (empieza)
        {
            gameObject.transform.forward = (new Vector3(player.transform.position.x - gameObject.transform.position.x, 0, player.transform.position.z - gameObject.transform.position.z)).normalized;
            switch (pasos)
            {
                case 0:
                    audioSource.clip = audiosMozo[currentAudio];
                    audioSource.Play();
                    currentAudio++;
                    pasos++;
                    break;
                case 1:
                    if(!audioSource.isPlaying)
                    {
                        objetosQueActivas[currentObjetosAActivar].SetActive(true);
                        currentObjetosAActivar++;
                        pasos++;
                    }
                    break;
                case 2:
                    if(mapa)
                    {
                        audioSource.clip = audiosMozo[currentAudio];
                        audioSource.Play();
                        currentAudio++;
                        pasos++;
                    }
                    break;
                case 3:
                    if (!audioSource.isPlaying)
                    {
                        objetosQueActivas[currentObjetosAActivar].SetActive(true);
                        currentObjetosAActivar++;
                        pasos++;
                    }
                    break;
                case 4:
                    if(saco)
                    {
                        audioSource.clip = audiosMozo[currentAudio];
                        audioSource.Play();
                        currentAudio++;
                        pasos++;
                    }
                    break;


            }
        }
    }
}
