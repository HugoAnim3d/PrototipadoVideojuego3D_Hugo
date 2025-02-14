using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour
{
    [SerializeField]
    private GameObject panelGameOver; //panel de reinicio
    [SerializeField]
    private Spawner enemyManager; //codigo de spawner de enemigos

    public void GameOver()
    {
        panelGameOver.SetActive(true); //activa el panel
        enemyManager.enabled = false; //detiene el spawner
        Cursor.lockState = CursorLockMode.Confined; //hace que el raton no pueda salir pero pueda interactuar con el panel
    }

    public void LoadSceneLevel()
    {
        SceneManager.LoadScene("Level01"); //carga la escena
    }
}
