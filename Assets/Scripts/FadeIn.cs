using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image image;
    public float speedToClear = 0.4f;
    private bool inverso;
    private bool activado;
    // Start is called before the first frame update
    void Start()
    {
        switchInverso(false);
        activado = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (activado)
        {
            if (!inverso)
            {
                image.color = image.color - new Color(0, 0, 0, speedToClear * Time.deltaTime);
                if (image.color.a <= 0.01)
                {
                    image.gameObject.SetActive(false);
                    image.color = image.color + new Color(0, 0, 0, 1);
                    gameObject.GetComponent<FadeIn>().enabled = false;
                    activado = false;
                }
            }
            else
            {
                image.color = image.color + new Color(0, 0, 0, speedToClear * Time.deltaTime);
                if (image.color.a >= 0.99)
                {
                    gameObject.GetComponent<FadeIn>().enabled = false;
                    activado = false;
                }
            }
        }
    }

    public void switchInverso(bool _inverso)
    {
        if(_inverso)
        {
            image.color = image.color - new Color(0, 0, 0, 1);
        }
        else
        {
            image.color = image.color + new Color(0, 0, 0, 1);
        }
        inverso = _inverso;
        image.gameObject.SetActive(true);
        activado = true;


    }
}
