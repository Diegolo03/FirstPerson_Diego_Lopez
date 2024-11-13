using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMunicion : MonoBehaviour
{
    private Animator anim;
    private int timmer=5;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    public void AbrirCaja()
    {
        anim.SetTrigger("Abriendo_Caja");
    }
    public void CerrarCaja()
    {
        anim.SetTrigger("Cerrando_Caja");
        StartCoroutine(CambioEstado());
    }
    IEnumerator CambioEstado()
    {
        yield return new WaitForSeconds(timmer);
        anim.SetTrigger("Cerrada");
        
    }
    
}
