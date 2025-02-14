using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; //prefab del enemigo
    [SerializeField]
    private Transform[] posRotEnemies; //array de posiciones de spawn
    [SerializeField]
    private float timeBetweenEnemies = 1; //tiempo que pasa entre cada aparicion

    void Start()
    {
        InvokeRepeating("CreateEnemies", 1.0f, timeBetweenEnemies); //hace que se creen enemigos de forma repetida
    }

    private void CreateEnemies()
    {
        int n = Random.Range(0, posRotEnemies.Length); //selecciona un objeto del array
        Instantiate(enemyPrefab, posRotEnemies[n].position, posRotEnemies[n].rotation); //crea un enemigo en el objeto seleccionado
    }
}
