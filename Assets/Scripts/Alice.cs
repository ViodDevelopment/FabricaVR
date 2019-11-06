using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice : MonoBehaviour
{
    public bool action = false;
    public bool finish = false;
    public Transform positionToGo;

    //Movimiento de volver al punto



    void Update()
    {
        if(action && !finish)
        {
            gameObject.transform.forward = (positionToGo.position - transform.position).normalized;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, positionToGo.transform.position, 0.75f * Time.deltaTime);
            if ((gameObject.transform.position - positionToGo.transform.position).magnitude <= 0.2f)
                finish = true;
        }
    }
}
