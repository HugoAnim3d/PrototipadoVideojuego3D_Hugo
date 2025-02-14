using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f; //velocidad a la que se mueve
    [SerializeField]
    private float distanceToPlayer = 2.0f; //distancia a la que se queda del jugador
    public GameObject player; //indicamos el objeto del juagdor
    [SerializeField]
    private Transform posRotBullet; //posicion de la que dispara
    [SerializeField]
    private GameObject bulletPrefab; //prefab de la bala
    [SerializeField]
    private float timeBetweenBullets = 0.5f; //tiempo de espera entre disparos
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //encuentra el player por su tag
        InvokeRepeating("Attack", 1, timeBetweenBullets); //hace que ataque en intervalos repetidos
    }

    void Update()
    {
        if(player == null)
        {
            CancelInvoke("Attack"); //comprueba si el player sigue existiendo y se detiene si no existe
            return;
        }
        transform.LookAt(player.transform.position); //mira al jugador
        followPlayer();
    }

    private void followPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position); //calcula la distancia entre jugador y enemigo
        if (distance > distanceToPlayer)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            } //se acerca al jugador hasta que llega a cierta distancia y no sigue
    }

    private void Attack()
    {
        Instantiate(bulletPrefab, posRotBullet.position, posRotBullet.rotation); //instancia el prefab
    }

}
