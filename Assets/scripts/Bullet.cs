using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int speed = 100; //velocidad de la bala

    void Start()
    {
        Destroy(gameObject, 5.0f); //destruye el prefab a los 5 segundos de ser creado
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //al ser creado, avanza hacia delante
    }
}
