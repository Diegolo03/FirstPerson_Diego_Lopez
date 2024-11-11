using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParteDeEnemigo : MonoBehaviour
{
    
    [SerializeField] private Enemigo mainScript;
    [SerializeField] private float multiplicadorDanho;

    public void RecibirDanho(float danhoRecibido)
    {
        mainScript.Vidas -= danhoRecibido*multiplicadorDanho;

        if (mainScript.Vidas <= 0)
        {
            mainScript.Morir();
        }
    }
}
