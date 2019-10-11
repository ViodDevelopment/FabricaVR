using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAndGo : MonoBehaviour {

    public float playerSpeed;
    public float cubeSpeed = 5f;
    private bool voyHacia = false;

    public GameObject CubeIAGameObject;
    public GameObject PlayerGameObject;


    private Vector3 cubeIAPosition;
    private Vector3 playerPosition;

    private Rigidbody cubeIARigidBody;



    // Use this for initialization
    void Start()
    {
        cubeIARigidBody = CubeIAGameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {



        cubeIAPosition = CubeIAGameObject.transform.position;
        playerPosition = PlayerGameObject.transform.position;


        float Distance = Vector3.Distance(playerPosition, cubeIAPosition); //Calculo la diferencia entre player y cubo




        if (Mathf.Abs(Distance) <= 33)
        {
            playerSpeed = 0f;
            
        }

        if (Mathf.Abs(Distance) >= 33)
        {
            playerSpeed = 3f;

        }

    }

    void FixedUpdate()
    {
       cubeIAPosition += Vector3.forward * Time.deltaTime;


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
}
