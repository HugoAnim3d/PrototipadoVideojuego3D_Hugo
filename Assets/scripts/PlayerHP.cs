using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 50.0f; //vida maxima del jugador
    [SerializeField]
    private float currentHealth; //vida actual del jugador
    [SerializeField]
    private float bulletDamage = 5.0f; //daño que recibe al ser golpeado
    [SerializeField]
    private Image lifeBar; //imagen de la barra de vida
    [SerializeField]
    private Panel gameManager; //el script del panel de reinicio
    [SerializeField]
    private ParticleSystem bigExplosion; //particulas de explosion 
    [SerializeField]
    private ParticleSystem smallExplosion;

    void Awake()
    {
        currentHealth = maxHealth; //indica que su vida al inicio es su vida maxima
        lifeBar.fillAmount = 1; //la imagen de la barra se rellena al tope
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemyBullet"))
	    {
            smallExplosion.Play(); //reproduce la animacion de particulas
            currentHealth -= bulletDamage; //daño recibido
            lifeBar.fillAmount = currentHealth / maxHealth; //calcula el porcentaje de vida restante
            Destroy(other.gameObject); //destruye el proyectil que ha chocado
            if (currentHealth <= 0) //si la vida es 0 activa muerte
                {
                    Death();//llama a la muerte
                }
        }

    }

    private void Death()
    { 
        bigExplosion.Play(); //reproduce la animacion de particulas
        Camera.main.transform.SetParent(null); //saca la camara
        Destroy(gameObject, 1.0f); 
        //destruye despues de un tiempo para que la animacion de muerte se vea
        gameManager.GameOver(); //llama al game over
    }

}
