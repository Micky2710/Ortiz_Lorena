using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    public Transform firepoint;
    public GameObject Balaprefab;
    public int salto;
    public int velocidad;
    public bool EnElPiso = false;
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.Play("Shoot");//Permite la animacion de disparar
            Shoot();
            
        }

        if(EnElPiso) 
        {
            //si hace contacto con el tag de piso, permite que la bool se transforme en true y pueda realizar la acción
            if (Input.GetKeyDown("space"))
            {

                anim.Play("Jump");//muestra la animacion de salto
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, salto));// le aggrega fuerza al salto
            }
            if (Input.GetKeyUp("space"))
            {
                EnElPiso = false;//vuelve la bool falsa para poder después volver a saltar
            }





        }

        
        

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, this.GetComponent<Rigidbody2D>().velocity.y); //aplica la velocidad al jugador


    }

    void Shoot ()
    {
        Instantiate(Balaprefab, firepoint.position, firepoint.rotation); //instancia la bala y la rota para poder dispararla
    }

    private void OnTriggerEnter2D(Collider2D c1)
    {
        //en cada uno de los obstáculos u enemigos si se llega a colisionar, provocará la muerte del jugador
        if (c1.tag == "Obstaculo")
        {
            GameOver.SetActive(true);
            GameObject.Destroy(this.gameObject);
        }

        if (c1.tag == "Enemigo")
        {
            GameOver.SetActive(true);
            GameObject.Destroy(this.gameObject);
        }
        //exceptuando la sangre, ya que esta es para ganar puntos
        if (c1.gameObject.CompareTag("Sangre"))
        {
            Destroy(c1.gameObject);//así al colisionar la que desaparece es la sangre y no el jugador
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "piso")
        {
            EnElPiso = true; //Vueleve la boll en false para saltar sólo una vez
        }
    }

}
