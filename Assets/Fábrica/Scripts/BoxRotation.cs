using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRotation : MonoBehaviour {

    public float rotationForce;
    private bool startRotation = false;

	void Update () {

        if (startRotation == true)
        transform.Rotate(0, rotationForce * Time.deltaTime, 0);
    }

    public void RotaciónDelCubo()
    {
        startRotation = true;
        
    }

    public void DejarDeRotar()
    {
        startRotation = false;
    }
}
