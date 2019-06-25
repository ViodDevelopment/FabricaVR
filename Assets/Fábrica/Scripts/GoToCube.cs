using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCube : MonoBehaviour
{

    public float speed;
    private bool voyHacia = false;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        if (voyHacia == true)
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;

    }

    public void IrHacia()
    {
        voyHacia = true;
    }

    public void DejarDeIrHacia()
    {
        voyHacia = false;
    }
}
