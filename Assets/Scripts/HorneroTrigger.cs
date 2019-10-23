using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorneroTrigger : MonoBehaviour
{
    int l_Count = 0;

    private void OnTriggerEnter(Collider other)
    {
        switch (l_Count)
        {
            case 0:
                GameManager.Instance.HorneroTriggerMobCarbonera();
                l_Count++;
                break;
            case 1:
                GameManager.Instance.HorneroTriggerMobCarbonara();
                l_Count++;
                break;
            case 2:
                GameManager.Instance.HorneroTriggerMobHorno();
                l_Count++;
                break;
            case 3:
                GameManager.Instance.HorneroTrigger();
                break;
        }
        
    }

}
