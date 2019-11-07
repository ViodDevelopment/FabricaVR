using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarYAndar : MonoBehaviour
{
    public LayerMask layer;
    public GoToCube goToCube;
    public Camera camera;
    // Update is called once per frame
    void Update()
    {
        RaycastHit rayhit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward,out rayhit, 200, layer))
        {
            if(rayhit.collider.gameObject.tag == "Taskmaster" || rayhit.collider.gameObject.tag == "CuboObjetivo")
            {
                goToCube.GoingTo(rayhit.collider.gameObject);
            }
            else
                goToCube.StopGoingTo();
        }
        else
            goToCube.StopGoingTo();

    }
}
