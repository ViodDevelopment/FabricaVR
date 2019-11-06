using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoDirector : MonoBehaviour
{
    public Animator animator;
    public AudioSource directorAudioSource;
    public AudioSource efectosAmbiente;
    public bool startScene;
    public bool tiene;
    private float firstSpeed;
    private int pasos;
    private int numOfAudios;
    private int numOfAudiosAmbiente;
    private float timer;
    public List<AudioClip> audios = new List<AudioClip>();
    public List<AudioClip> audiosAmbientes = new List<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        startScene = false;
        tiene = false;
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
                //directorAudioSource.clip = audios[numOfAudios];
                //directorAudioSource.Play();
                numOfAudios++;
                pasos++;
            }
            else
            if (pasos == 1 && !directorAudioSource.isPlaying)
            {
                animator.speed = firstSpeed;
                pasos++;
                timer = 5.65f;
            }
            else if (pasos == 2 && timer == 0)
            {
                //directorAudioSource.clip = audios[numOfAudios];
                //directorAudioSource.Play();
                efectosAmbiente.clip = audiosAmbientes[numOfAudiosAmbiente];
                efectosAmbiente.Play();
                numOfAudiosAmbiente++;
                numOfAudios++;
                pasos++;
                timer = 0.3f;
            }
            else if (pasos == 3 && timer == 0)
            {
                //directorAudioSource.clip = audios[numOfAudios];
                //directorAudioSource.Play();
                numOfAudios++;
                animator.SetBool("Pide", true);
                pasos++;
            }
            else if (pasos == 4 && tiene)
            {
                //directorAudioSource.clip = audios[numOfAudios];
                //directorAudioSource.Play();
                numOfAudios++;
                animator.SetBool("Tiene", true);
                pasos++;
                timer = 3f;
            }
            else if(pasos == 5 && timer == 0)
            {
                //directorAudioSource.clip = audios[numOfAudios];
                //directorAudioSource.Play();
                numOfAudios++;
                //dar el sobre
                pasos++;
                timer = 5f;
            }
            else if(pasos == 6 && timer == 0)
            {
                //volver a sentarse el director
                //directorAudioSource.clip = audios[numOfAudios];
                //directorAudioSource.Play();
                numOfAudios++;
                gameObject.GetComponent<DialogoDirector>().enabled = false;
            }
        }

    }
}
