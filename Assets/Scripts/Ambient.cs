using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Ambient : MonoBehaviour
{
    Material material;
    bool ShowLighting = false;
    private void OnMouseDown()
    {
        ShowLighting = !ShowLighting;
        if (ShowLighting)
            material.SetFloat("_ShowLighting", 1);
        else
            material.SetFloat("_ShowLighting", 0);

    }
    // Start is called before the first frame update
    void Start()
    {
        material = this.GetComponent<Renderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
