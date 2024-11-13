using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distanciaInteraccion;
    [SerializeField] private Transform interactuableActual;
    private bool interactuado = false;
  

    void Start()
    {
        cam = Camera.main;
        
    }
    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit PointInfo, distanciaInteraccion))
        {
            if (PointInfo.transform.TryGetComponent(out CajaMunicion scriptCaja))
            {
                interactuableActual = PointInfo.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;
                if (Input.GetKeyDown(KeyCode.E)&& interactuado==false)
                {
                    scriptCaja.AbrirCaja();
                    StartCoroutine(CambioEstado());
                    interactuado = true;

                }
                else if (Input.GetKeyDown(KeyCode.E) && interactuado==true)
                {
                    scriptCaja.CerrarCaja();
                    interactuado = false;
                }
            }
            
        }
        else if (interactuableActual)
        {
            interactuableActual.GetComponent<Outline>().enabled = false;
            interactuableActual = null;
        }
    }
    IEnumerator CambioEstado()
    {
        yield return new WaitForSeconds(1);

    }
}
