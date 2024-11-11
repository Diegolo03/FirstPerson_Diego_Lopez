using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private NavMeshAgent agent;
    private FirstPerson player;
    private Animator anim;
    private Rigidbody[] huesos;
    private bool ventanaAbierta;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radioAtaque = 0.3f;
    [SerializeField] private float dano;
    private float danhoRecibido;
    private bool danorealizado=false, estado;
    [SerializeField] private LayerMask queEsPlayer;
    private FirstPerson fp;
    [SerializeField] private float vidas=100;
    public float Dano { get => dano; set => dano = value; }
    public float Vidas { get => vidas; set => vidas = value; }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<FirstPerson>();
        huesos = GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
        CambiarEstadosHuesos(true);
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();
        if (ventanaAbierta && danorealizado==false) 
        {
            DetectarJugador();
        }
    }

    private void DetectarJugador()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(attackPoint.position, radioAtaque, queEsPlayer);
        if (collsDetectados.Length > 0)
        {

            for (int i = 0; i < collsDetectados.Length; i++)
            {
                collsDetectados[i].GetComponent<FirstPerson>().RecibirDano(dano);

            }
            danorealizado = true;


        }
    }
    private void OnDrawGizmos()
    {

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(attackPoint.position, radioAtaque);
    }

    
    private void Perseguir()
    {
        agent.SetDestination(player.transform.position);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("Attacking", true);


        }
    }
    public void Morir()
    {
        agent.enabled = false;
        anim.enabled = false;
        CambiarEstadosHuesos(false);
        // pasados 10 seg o lo que pongas desaparece 
        Destroy(gameObject, 10);
    }
    private void CambiarEstadosHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }
    //public void RecibirDanho(float danhoRecibido)
    //{
    //    vidas -= danhoRecibido;

    //    if (vidas <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    #region Eventos Animacion
    private void FinAtaque()
    {
        agent.isStopped = false;
        danorealizado = false;
        anim.SetBool("Attacking", false);
    }
    #endregion
    private void AbrirVentanaAtaque()
    {
        ventanaAbierta = true;
    }
   
    private void CerrarVentanaAtaque()
    {
        ventanaAbierta = false;
    }
}
