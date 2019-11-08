using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public bool x = false;
    public bool y = false;
    public bool z = false;

    public float speed;

    void Update()
    {
        if (x)
            transform.Rotate(speed * Time.deltaTime, 0, 0);
        else if (y)
            transform.Rotate(0,speed * Time.deltaTime, 0);
        else if (z)
            transform.Rotate(0,0,speed * Time.deltaTime);
    }
}
