using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoDirector : MonoBehaviour
{
    public Animator animator;
    public AudioSource directorAudioSource;
    public AudioSource efectosAmbiente;
    public GameObject periodico;
    public bool startScene;
    public bool tiene;
    public bool algoMas;
    private float firstSpeed;
    public int pasos;
    private int numOfAudios;
    private int numOfAudiosAmbiente;
    private float timer;
    public bool acabado;
    public List<AudioClip> audios = new List<AudioClip>();
    public List<AudioClip> audiosAmbientes = new List<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        startScene = false;
        tiene = false;
        algoMas = false;
        acabado = false;
        firstSpeed = animator.speed;
        animator.speed = 0;
        pasos = 0;
        numOfAudios = 0;
        numOfAudiosAmbiente = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (startScene)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                    timer = 0;
            }

            if (pasos == 0)
            {
                directorAudioSource.clip = audios[numOfAudios];
                directorAudioSource.Play();
                numOfAudios++;
                pasos++;
                animator.speed = firstSpeed;
            }
            else
            if (pasos == 1)
            {
                pasos++;
                timer = 5.75f;
            }
            else if (pasos == 2 && timer == 0)
            {
                directorAudioSource.clip = audios[numOfAudios];
                directorAudioSource.Play();
                efectosAmbiente.clip = audiosAmbientes[numOfAudiosAmbiente];
                efectosAmbiente.Play();
                numOfAudiosAmbiente++;
                numOfAudios++;
                pasos++;
                timer = 1f;
            }
            else if (pasos == 3 && timer == 0)
            {
                animator.SetBool("Pide", true);
                pasos++;
            }
            else if (pasos == 4 && tiene)
            {
                directorAudioSource.clip = audios[numOfAudios];
                directorAudioSource.Play();
                numOfAudios++;
                animator.SetBool("Tiene", true);
                pasos++;
                timer = 0.1f;
            }
            else if (pasos == 5 && timer == 0)
            {
                periodico.SetActive(true);
                timer = 3f;
                pasos++;
            }
            else if (pasos == 6 && timer == 0 && !directorAudioSource.isPlaying)
            {
                if (SingletoneGender.GetInstance().GetGender() == SingletoneGender.Gender.MALE)
                {
                    directorAudioSource.clip = audios[numOfAudios];
                    numOfAudios++;
                }
                else
                {
                    numOfAudios++;
                    directorAudioSource.clip = audios[numOfAudios];
                }
                directorAudioSource.Play();
                numOfAudios++;
                algoMas = true;
                animator.SetBool("AlgoMas", true);
                //dar el sobre
                pasos++;
                timer = 5f;
            }
            else if (pasos == 7 && !algoMas && !directorAudioSource.isPlaying)
            {
                //volver a sentarse el director
                directorAudioSource.clip = audios[numOfAudios];
                directorAudioSource.Play();
                animator.SetBool("AlgoMas", false);
                numOfAudios++;
                gameObject.GetComponent<DialogoDirector>().enabled = false;
                pasos++;
            }
            else if(pasos == 8 && !directorAudioSource.isPlaying)
            {
                acabado = true;
                gameObject.GetComponent<DialogoDirector>().enabled = false;
            }
        }

    }

    public void NextSoundAmbiente()
    {
        if (numOfAudiosAmbiente < audiosAmbientes.Count)
        {
            efectosAmbiente.clip = audiosAmbientes[numOfAudiosAmbiente];
            efectosAmbiente.Play();
            numOfAudiosAmbiente++;
        }
    }
}
