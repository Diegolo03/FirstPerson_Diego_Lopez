using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] private ParticleSystem system;
    private Animator anim;
    private int timmer = 5;
    
    // Start is called before the first frame update
    private Camera cam;
    void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            anim.SetBool("Inspeccionando", true);
            if (Input.GetKeyDown(KeyCode.Y))
            {
                anim.SetBool("Inspeccionando", false);
            }
                

        }
        if (Input.GetMouseButtonDown(0))
        {

           system.Play();

           if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
           {
                if(hitInfo.transform.CompareTag("ParteEnemigo"))
                hitInfo.transform.GetComponent<ParteDeEnemigo>().RecibirDanho(misDatos.danhoAtaque);

           }

        }
    }
    public void DejarInspeccion()
    {
        anim.SetBool("Inspeccionando", false);
    }

}
