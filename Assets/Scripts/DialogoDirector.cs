using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoDirector : MonoBehaviour
{
    public Animator animator;
    public AudioSource directorAudioSource;
    public AudioSource efectosAmbiente;
    public GameObject periodico;
    public GameObject cubo;
    public bool startScene;
    public bool tiene;
    public bool algoMas;
    private float firstSpeed;
    public int pasos;
    private int numOfAudios;
    private int numOfAudiosAmbiente;
    public GameObject capataz;
    private int layer;
    private float timer;
    public bool acabado;
    public List<AudioClip> audios = new List<AudioClip>();
    public List<AudioClip> audiosAmbientes = new List<AudioClip>();
    public List<Animation> animations = new List<Animation>();
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
        layer = capataz.layer;
        numOfAudios = 0;
        numOfAudiosAmbiente = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetLayerWeight(2, Mathf.Clamp(Mathf.Sin(Time.time), 0, 1));

        if (directorAudioSource.isPlaying)
            animator.SetLayerWeight(1, 1);
        else animator.SetLayerWeight(1, 0);

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
                animator.speed = firstSpeed;
                numOfAudios++;
                pasos++;
                cubo.SetActive(true);
            }
            else
            if (pasos == 1)
            {
                pasos++;
                timer = 5f;
            }
            else if (pasos == 2 && timer == 0)
            {
                //directorAudioSource.clip = audios[numOfAudios];
                //directorAudioSource.Play();
                efectosAmbiente.clip = audiosAmbientes[numOfAudiosAmbiente];
                efectosAmbiente.Play();
                numOfAudiosAmbiente++;
                //numOfAudios++;
                pasos++;
                timer = 1.75f;
            }
            else if (pasos == 3 && timer == 0)
            {
                animator.SetBool("Pide", true);
                pasos++;
                timer = 3.5f;
            }
            else if(pasos == 4 && timer == 0 && !tiene && !animations[0].isPlaying)
            {
                animations[0].Play();
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
                animations[1].Play();
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
                pasos++;
            }
            else if(pasos == 8 && !directorAudioSource.isPlaying)
            {
                acabado = true;
                capataz.layer = layer;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehabioursPlanta2>().m_MoveToNextPoint = true;
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

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player" && !startScene)
        {
            startScene = true;
            capataz.layer = 5;
        }
    }
}
