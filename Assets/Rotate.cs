using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
   public float Speed;
    public Vector3 DegreesTo;

    void Update()
    {
        if(this.transform.rotation.y>=DegreesTo.y)
        this.transform.Rotate(DegreesTo, Speed*Time.deltaTime);
    }
}
