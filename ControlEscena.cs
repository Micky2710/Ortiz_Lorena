using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlEscena : MonoBehaviour
{
    public GameObject jugador;
    public Camera camara;
    public GameObject[] BloquePrefab;
    public float puntero;
    public float LugarGeneracion = 12;
    public Text TextoJuego;
    public bool perdiste;
    

    // Start is called before the first frame update
    void Start()
    {
        puntero = -7;
        //perdiste = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador != null )
        {
            camara.transform.position = new Vector3(jugador.transform.position.x, camara.transform.position.y, camara.transform.position.z);
            TextoJuego.text = "Puntos" + Mathf.Floor (jugador.transform.position.x);
            // Permite que la cámara siga al jugador
        }

        else

        {
            //if (perdiste)
            //{
            //    perdiste = true;
                
            //}

            //if (perdiste)
            //{
            //    if (Input.GetKeyDown("S"))
            //    {
            //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //    }
            //}
        }

        //Maneja el generador de escenario
        while (jugador != null && puntero<jugador.transform.position.x + LugarGeneracion)
        {
            int indicebloque = Random.Range(0, BloquePrefab.Length - 1); //Busca entre los prefabs de pisos y va generando uno aleatoriamente

            if (puntero < 0)
            {
                indicebloque = 2;
            }

            GameObject ObjetoBloque = Instantiate(BloquePrefab[indicebloque]);
            ObjetoBloque.transform.SetParent(this.transform);
            Bloque bloque = ObjetoBloque.GetComponent<Bloque>();
            ObjetoBloque.transform.position = new Vector2(puntero + bloque.tamaño / 2, 0);
            puntero += bloque.tamaño;
            //Ajusta la posicion en la cual se van a generar los pisos, ajusta el tamaño y permite que el puntero vaya aumentando
        }
    }
}
