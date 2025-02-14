using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barToCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position); //hace que la barra de vida del enemigo mire a la main camera
    }
}
