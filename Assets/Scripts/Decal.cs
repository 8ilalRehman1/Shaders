using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Decal : MonoBehaviour
{
    Material mat;

    bool showDecal = false;

    private void OnMouseDown()
    {
        showDecal = !showDecal;
        if (showDecal)
            mat.SetFloat("_ShowDecal", 1);
        else
            mat.SetFloat("_ShowDecal", 0);
    }
    // Start is called before the first frame update
    //use this for initialization 
    void Start()
    {
        mat = this.GetComponent<Renderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
