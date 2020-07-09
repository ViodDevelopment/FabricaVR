using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetCorrea : MonoBehaviour
{
   public  Material m_Material;
    
    Vector2 currentVector = new Vector2(0,0);
    public float speed;

    void Update()
    {

        if (m_Material.GetTextureOffset("_MainTex").y <= -1)
        {
            m_Material.SetTextureOffset("_MainTex", new Vector2(0, 0));
            currentVector = new Vector2(0, 0);
        }
        else
        {
            currentVector.y -= speed * Time.deltaTime;
            m_Material.SetTextureOffset("_MainTex", currentVector);
        }
    }
}
