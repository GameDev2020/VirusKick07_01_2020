using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skybox_movement : MonoBehaviour
{
    public float RotateSkybox = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotateSkybox);

    }
}
