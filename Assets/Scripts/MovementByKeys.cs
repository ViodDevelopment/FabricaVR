using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementByKeys : MonoBehaviour
{
    private CharacterController m_CharacterController;
    public float m_Speed;
    public float m_Sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        m_Speed = 2f;
        m_Sensitivity = 1f;
        m_CharacterController = GetComponent<CharacterController>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            m_CharacterController.Move(gameObject.transform.forward * m_Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_CharacterController.Move(gameObject.transform.right * m_Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            m_CharacterController.Move(gameObject.transform.right * m_Speed * Time.deltaTime * -1f);
        }

        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        transform.RotateAround(gameObject.transform.position, -Vector3.up, rotateHorizontal * m_Sensitivity * -1f);
    }
}
