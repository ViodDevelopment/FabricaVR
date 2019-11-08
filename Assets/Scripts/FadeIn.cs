using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image image;
    public float speedToClear = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        image.color = image.color + new Color(0, 0, 0, 1);
        image.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        image.color = image.color - new Color(0, 0, 0, speedToClear * Time.deltaTime);
        if (image.color.a <= 0.05)
        {
            image.gameObject.SetActive(false);
            image.color = image.color + new Color(0, 0, 0, 1);
            gameObject.GetComponent<FadeIn>().enabled = false;
        }

    }
}
