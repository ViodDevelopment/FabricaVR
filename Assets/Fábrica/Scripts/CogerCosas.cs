﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CogerCosas : MonoBehaviour
{
    public FadeIn fader;
    public Image image;
    public bool periodico;
    public bool sobre;
    private float timer = 0;
    public List<Sprite> textures = new List<Sprite>();
    public DialogoDirector director;
    public MozoDeAlmacen mozo;
    private bool terminado1;
    private GameObject objetoCogido;
  

    void Start()
    {
        periodico = false;
        sobre = false;
        terminado1 = false;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
            }
        }
        if (!terminado1)
        {
            if (sobre || periodico)
            {

                if (objetoCogido != null && objetoCogido.GetComponentInChildren<Animation>() != null)
                {
                    if(objetoCogido.GetComponentInChildren<Animation>().isPlaying)
                        objetoCogido.GetComponentInChildren<Animation>().Stop();
                }
                //.color = image.color - new Color(0, 0, 0, Time.deltaTime);
                //fader.image.color = fader.image.color - new Color(0, 0, 0, Time.deltaTime);
                if (timer == 0)
                {
                    //image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                    //fader.image.color = new Color(fader.image.color.r, fader.image.color.g, fader.image.color.b, 0);
                    //image.gameObject.SetActive(false);
                    //fader.image.gameObject.SetActive(false);
                    Destroy(objetoCogido);
                    objetoCogido = null;
                    if (periodico)
                    {
                        periodico = false;
                        director.tiene = true;
                    }
                    else if (sobre)
                    {
                        sobre = false;
                        director.algoMas = false;
                        terminado1 = true;
                    }
                }

            }
            if (director.pasos >= 4)
            {
                RaycastHit raycastHit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 5f))
                {
                    if (raycastHit.collider.gameObject.name == "Despacho_Escritorio_Periodico_geo" && director.animations[0].isPlaying && director.cubo == null && !periodico)
                    {
                        periodico = true;
                        //image.sprite = textures[0];
                        //image.gameObject.SetActive(true);
                        raycastHit.collider.gameObject.GetComponentInChildren<Animation>().Stop();
                        objetoCogido = raycastHit.collider.gameObject;
                        objetoCogido.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.5f;
                        objetoCogido.transform.forward = -Camera.main.transform.forward;
                        objetoCogido.transform.parent = Camera.main.transform;
                        timer = 6;
                        director.NextSoundAmbiente();
                        //fader.enabled = true;
                    }

                    if (director.algoMas && raycastHit.collider.gameObject.name == "Despacho_Escritorio_Sobre_geo" && !sobre)
                    {
                        timer = 5;
                        sobre = true;
                        /*if (SingletoneGender.GetInstance().GetGender() == SingletoneGender.Gender.MALE)
                        {
                            image.sprite = textures[1];
                        }
                        else
                        {
                            image.sprite = textures[2];
                        }*/
                        // image.gameObject.SetActive(true);
                        raycastHit.collider.gameObject.GetComponentInChildren<Animation>().Stop();
                        objetoCogido = raycastHit.collider.gameObject;
                        objetoCogido.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 0.5f;
                        objetoCogido.transform.forward = -Camera.main.transform.forward;
                        objetoCogido.transform.parent = Camera.main.transform;
                        director.NextSoundAmbiente();
                        //raycastHit.collider.gameObject.SetActive(false);
                        //fader.enabled = true;
                    }

                }
            }
        }
        else if (mozo.empieza)
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, 5f))
            {
                if (mozo.objetosQueActivas[0] == null && raycastHit.collider.gameObject.name == "1505Mapa")
                {
                    raycastHit.collider.gameObject.GetComponent<BoxCollider>().enabled = false;
                    mozo.mapa = true;
                }

                if (raycastHit.collider.gameObject.name == "Saco1505")
                {
                    Destroy(raycastHit.collider.gameObject);
                }
            }
        }
    }
}
