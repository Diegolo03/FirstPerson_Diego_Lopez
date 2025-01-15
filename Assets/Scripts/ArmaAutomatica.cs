using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaAutomatica : MonoBehaviour
{
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] private ParticleSystem system;
    [SerializeField] private AudioSource aus;
    private Animator anim;
    private float timmer;
    
    // Start is called before the first frame update
    private Camera cam;
    void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main;
        timmer = misDatos.cadenciaAtaque;
    }

    // Update is called once per frame
    void Update()
    {
        timmer+=1*Time.deltaTime;
        if (Input.GetMouseButton(0) && timmer >= misDatos.cadenciaAtaque) 
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
            timmer = 0;

        }
    }
    private void ReproducirSonido(AudioClip clip)
    {
        aus.PlayOneShot(clip);

    }

}
