using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChargeMenu : MonoBehaviour
{
    public AnimationEvent CallScene;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
     void ChargeScene()
    {
         SceneManager.LoadScene(1);
    }
}
