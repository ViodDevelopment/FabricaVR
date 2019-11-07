using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sobre : MonoBehaviour
{
    public List<Material> textures = new List<Material>();
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (SingletoneGender.GetInstance().GetGender() == SingletoneGender.Gender.MALE)
            meshRenderer.material = textures[0];
        else
            meshRenderer.material = textures[1];

    }
}
