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
    public PlayerBehabioursPlanta2 player;
    private int currentObjetosAActivar;
    private int pasos;
    public Transform transformMozo;

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
                    transformMozo.forward = new Vector3(transformMozo.position.x - player.transform.position.x,0, transformMozo.position.z - player.transform.position.z).normalized;
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
                    break;
            }
        }
    }
}
