using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToMove : MonoBehaviour
{
    public float cubeSpeed = 5f;

    public Transform[] pointPosition;

    [HideInInspector] public bool notPressed = false;

    private GoToCubeIA goToCubeIAScript;

    public GameObject goToCubeIAGameObject;

    void Start ()
    {
        goToCubeIAScript = goToCubeIAGameObject.GetComponent<GoToCubeIA>();
    }
	
	void Update ()
    {
        if (notPressed == true)
             transform.position = Vector3.MoveTowards(transform.position, pointPosition[goToCubeIAScript.counter].position, cubeSpeed * Time.deltaTime);
	}
}
