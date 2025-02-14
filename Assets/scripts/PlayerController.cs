using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private int speed = 50; //velocidad del prota
    [SerializeField]
    private int turnSpeed = 125; //cuanto gira

    [Header("Attack")]
    [SerializeField]
    private GameObject bulletPrefab; //prefab de la bala
    [SerializeField]
    private Transform posRotBullet; //empty desde el que se lanza la bala
    [SerializeField]
    private AudioSource grito; //sonido al disparar

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; //bloquea el raton a la pantalla de juego
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal"); //pilla el input horizontal
        float vertical = Input.GetAxis("Vertical"); //pilla el input vertical
        Vector3 direction = new Vector3(horizontal, 0, vertical); //nuevo vector para el movimiento
        transform.Translate(direction.normalized * speed * Time.deltaTime); //transforma el input en movimiento, normalized hace que vaya a la misma velocidad en todas direcciones
    }

    private void Turning()
    {
        float xMouse = Input.GetAxis("Mouse X"); //pilla el input horizontal del raton
        float yMouse = Input.GetAxis("Mouse Y"); //pilla el input vertical del raton
        Vector3 rotation = new Vector3(0, xMouse, 0); //vector para el giro
        transform.Rotate(rotation * turnSpeed * Time.deltaTime); //transforma el input del raton en giro del personaje
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, posRotBullet.position, posRotBullet.rotation);
            grito.Play(); //al hacer click lanza un proyectil y reproduce un movimiento
        }
    }

    void Start()
    {
        
    }

    void Update() //llama a los metodos en todo momento
    {
        Movement();
        Turning();
        Attack();
    }
}
