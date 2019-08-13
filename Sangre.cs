using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sangre : MonoBehaviour
{
    public int SangreValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))//Compara el tag del jugador para contar el score
        {
            ScoreManager.instance.ChangeScore(SangreValue);//manda llamar el valor del objeto
        }
    }
}
