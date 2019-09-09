using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCube : MonoBehaviour
{
    public float speed;
    private bool voyHacia = false;
    GameObject objeto;

    void FixedUpdate()
    {
        if (voyHacia == true)
        {
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;

            if (objeto == null)
                DejarDeIrHacia();
        }
        else
        {
            DejarDeIrHacia();
        }
    }

    public void IrHacia(GameObject l_objeto)
    {
        objeto = l_objeto;
        voyHacia = true;
    }

    public void DejarDeIrHacia()
    {
        voyHacia = false;
    }
}
