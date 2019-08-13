using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour
{

    private float length, startpos;
    public GameObject cam;
    public float ParallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        //ubica la posicion donde se generará el fondo 
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;//ajusta el tamaño a la pantalla
    }

    private void FixedUpdate()
    {
        float dist = (cam.transform.position.x * ParallaxEffect); // hace el efecto de movimiento en diferentes velocidades
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);// moviendo las posiciones de cada objeto del fondo
    }
}
