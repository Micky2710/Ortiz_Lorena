using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void fin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0); //cambia de escena para mandar la pantalla de game over y reiniciar el juego
    }
}
