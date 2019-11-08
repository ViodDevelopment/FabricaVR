using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MozoDeAlmacen : MonoBehaviour
{
    public bool empieza;
    public List<AudioClip> audiosMozo = new List<AudioClip>();
    private int currentAudio;
    public AudioSource audioSource;
    public List<GameObject> objetosQueActivas = new List<GameObject>();
    private int currentObjetosAActivar;
    private int pasos;

    // Start is called before the first frame update
    void Start()
    {
        empieza = false;
        currentAudio = 0; 
        currentObjetosAActivar = 0;
        pasos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (empieza)
        {
            switch (pasos)
            {
                case 0:
                    audioSource.clip = audiosMozo[currentAudio];
                    audioSource.Play();
                    currentAudio++;
                    pasos++;
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }
    }
}
