using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastSustitute : MonoBehaviour
{
    public LayerMask layerMask;
    public ChargeMenu holder;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit rayhit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out rayhit, 1000, layerMask))
        {
            if (rayhit.collider.gameObject.name == "Start")
            {
                holder.ActivateStart();
            }
            else
                holder.DesactivateStart();

            if (rayhit.collider.gameObject.name == "Mal")
            {
                holder.ActivateMale();
            }
            else
                holder.DesacativateMale();

            if (rayhit.collider.gameObject.name == "Fem")
            {
                holder.ActivateFem();
            }
            else
                holder.DesactivateFem();


            if (rayhit.collider.gameObject.name == "Credits")
            {
                holder.ActivateCred();
            }
            else
                holder.DesacativateCred();


            if (rayhit.collider.gameObject.name == "Exit")
            {
                holder.ActivateExit();
            }
            else
                holder.DesacativateExit();


        }
        else
        {
            holder.DesactivateStart();
            holder.DesacativateExit();
            holder.DesacativateCred();
            holder.DesactivateFem();
            holder.DesacativateMale();

        }
    }
}
