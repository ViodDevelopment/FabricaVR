using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCubeIA : MonoBehaviour
{

    public float playerSpeed;
    private bool voyHacia = false;

    public GameObject CubeIAGameObject;
    public GameObject PlayerGameObject;

    private Vector3 cubeIAPosition;
    private Vector3 playerPosition;


    private PressToMove cubeIAScript;

    public int counter;

    private bool onlyOne = true;

    private bool imHere = true;


    // Use this for initialization
    void Start()
    {
        cubeIAScript = CubeIAGameObject.GetComponent<PressToMove>();
    }

    // Update is called once per frame
    void Update()
    {

       cubeIAPosition = CubeIAGameObject.transform.position;
       playerPosition = PlayerGameObject.transform.position;


        float Distance = Vector3.Distance(playerPosition, cubeIAPosition); //Calculo la diferencia entre player y cubo


        if (Mathf.Abs(Distance) <= 33)
        {
            if (imHere == true)
            {
                playerSpeed = 0f;
                Invoke("CubeGoAway", 2f);
                imHere = false;
            }
            
        }
         

    }

    void FixedUpdate()
    {

        if (voyHacia == true)
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;

    }

    public void IrHacia()
    {
        voyHacia = true;
    }

    public void DejarDeIrHacia()
    {
        voyHacia = false;
    }

    public void ReturnSpeed()
    {
        playerSpeed = 3f;
        onlyOne = true;
        print("Te mueves");
        imHere = true;
    }

    public void CubeGoAway()
    {
        print("Cubo se mueve");
        cubeIAScript.notPressed = true;
        Invoke("ReturnSpeed", 5f);
        onlyOne = false;
        counter++;
    }
}
