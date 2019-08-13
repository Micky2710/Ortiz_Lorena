using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if (instance==null)
        {
            instance = this; 
        }
        //si el objeto es nulo manda llamar los componentes  
    }

   public void ChangeScore (int SangreValue)
    {
        //suma al puntaje dependiendo las bolsas de sangre que vayas recolectando
        score += SangreValue;
        text.text = "X" + score.ToString();//las puntua en la pantalla del juego
    }
}
