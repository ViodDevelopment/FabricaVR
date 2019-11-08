using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDeInicioDelMozo : MonoBehaviour
{
    public MozoDeAlmacen mozo;



    private void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            mozo.empieza = true;
            Destroy(gameObject);
        }
    }
}
