using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] private ParticleSystem system;
    [SerializeField] private AudioSource aus;
    private Animator anim;
    
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

            anim.SetTrigger("Inspeccionando");

        }
        if (Input.GetMouseButtonDown(0))
        {
            ReproducirSonido(aus.clip);
            system.Play();

           if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
           {
                if (hitInfo.transform.CompareTag("ParteEnemigo"))
                {
                    hitInfo.transform.GetComponent<ParteDeEnemigo>().RecibirDanho(misDatos.danhoAtaque);

                }

           }

        }
    }
    private void ReproducirSonido(AudioClip clip)
    {
        aus.PlayOneShot(clip);

    }

}
