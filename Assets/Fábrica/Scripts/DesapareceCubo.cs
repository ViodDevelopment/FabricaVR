﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesapareceCubo : MonoBehaviour
{
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 1.5f)
        {
            
            Destroy(this.gameObject);
        }
    }
}
