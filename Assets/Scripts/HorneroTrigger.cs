using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorneroTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.HorneroTrigger();
    }
}
