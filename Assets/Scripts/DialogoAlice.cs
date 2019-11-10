using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoAlice : MonoBehaviour
{
    public List<GameObject> points = new List<GameObject>();
    public Alice alice;
    public List<AudioClip> clips = new List<AudioClip>();
    public AudioSource audioCapataz;
    public AudioSource audioAlice;
    private float currentTime = 0;
    private int currentClip = 0;
    public bool acabado = false;
    public Animator animator;
    public Transform rotateAlice;
    private int lastLayer = 0;
    private float timerAlice;

    void Start()
    {
        lastLayer = audioCapataz.gameObject.layer;
        animator.SetBool("Idle", true);
    }

    void Update()
    {
        if(audioAlice.isPlaying)
        {
            animator.SetLayerWeight(1, 1);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
        if (!acabado)
        {
            if (points[0] == null && currentClip == 0)
            {
                audioCapataz.gameObject.layer = 5;
                audioCapataz.clip = clips[currentClip];
                audioCapataz.Play();
                points[1].SetActive(true);
                currentClip++;
            }

            if (points[1] == null && !audioCapataz.isPlaying && currentClip == 1)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= 0.1f)
                {
                    currentTime = 0;
                    audioCapataz.clip = clips[currentClip];
                    audioCapataz.Play();
                    currentClip++;
                }
            }

            if (currentClip == 2 && !audioCapataz.isPlaying && !alice.action)
            {
                alice.action = true;
                animator.SetBool("Idle", false);
            }

            if (currentClip == 2 && alice.finish)
            {
                audioAlice.clip = clips[currentClip];
                audioAlice.Play();
                animator.SetBool("Idle", true);
                currentClip++;
            }

            if (currentClip == 3 && !audioAlice.isPlaying)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= 0.1f)
                {
                    currentTime = 0;
                    audioCapataz.clip = clips[currentClip];
                    audioCapataz.Play();
                    currentClip++;
                }
            }

            if (currentClip == 4 && !audioCapataz.isPlaying)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= 0.1f)
                {
                    currentTime = 0;
                    audioAlice.clip = clips[currentClip];
                    audioAlice.Play();
                    currentClip++;
                }
            }

            if (currentClip == 5 && !audioAlice.isPlaying)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= 0.1f)
                {
                    currentTime = 0;
                    audioCapataz.clip = clips[currentClip];
                    audioCapataz.Play();
                    currentClip++;
                    animator.SetBool("Idle", false);
                    animator.SetBool("Agacha", true);
                    gameObject.transform.forward = (new Vector3(rotateAlice.transform.position.x - gameObject.transform.position.x, 0 , rotateAlice.transform.position.z - gameObject.transform.position.z)).normalized;

                }
            }

            if (currentClip == 6 && !audioCapataz.isPlaying)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= 8.5f)
                {
                    animator.SetBool("Agacha", false);
                    animator.SetBool("Idle", true);
                    currentTime = 0;
                    audioAlice.clip = clips[currentClip];
                    audioAlice.Play();
                    currentClip++;
                    timerAlice = 0.2f;
                }
            }

            if(timerAlice > 0)
            {
                timerAlice -= Time.deltaTime;
                if(timerAlice <= 0)
                {
                    timerAlice = 0;
                    gameObject.transform.forward = (new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x - gameObject.transform.position.x, 0, GameObject.FindGameObjectWithTag("Player").transform.position.z - gameObject.transform.position.z)).normalized;
                }
            }

            if (currentClip == 7 && !audioAlice.isPlaying)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= 0.1f)
                {
                    currentTime = 0;
                    audioCapataz.clip = clips[currentClip];
                    audioCapataz.Play();
                    acabado = true;
                }
            }
        }
        else
        {
            if(!audioCapataz.isPlaying)
            {
                audioCapataz.gameObject.layer = lastLayer;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehabioursPlanta2>().m_MoveToNextPoint = true;
                gameObject.GetComponent<DialogoAlice>().enabled = false;
            }
        }
    }
}
