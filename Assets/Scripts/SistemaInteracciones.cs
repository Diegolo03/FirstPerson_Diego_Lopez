using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SistemaInteracciones : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distanciaInteraccion;
    private int recogido;
    [SerializeField] private Transform interactuableActual;
    [SerializeField] private GameObject[] objetoColeccionable, clonObjetoInteractuable;
    [SerializeField] private Image[] imagenObjetoInteractuable;
    [SerializeField] private TimeCountDown timeCountDown;
    private bool interactuado = false;
    [SerializeField] private FirstPerson fp;

    void Start()
    {
        cam = Camera.main;
        for (int i = 0; i < objetoColeccionable.Length; i++)
        {
            clonObjetoInteractuable[i].gameObject.SetActive(false);
        }
    }
    void Update()
    {

        


        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit PointInfo, distanciaInteraccion))
        {
            if (PointInfo.transform.TryGetComponent(out CajaMunicion scriptCaja)|| PointInfo.transform.CompareTag("Coleccionable"))
            {
                interactuableActual = PointInfo.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;
                if (PointInfo.transform.CompareTag("Coleccionable"))
                {
                    CogerObjetos();
                }
                else if (Input.GetKeyDown(KeyCode.E)&& interactuado==false)
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
        yield return new WaitForSeconds(0.5f);

    }
    private void CogerObjetos()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit PointInfo, distanciaInteraccion))
            {
                if (PointInfo.transform.CompareTag("Coleccionable"))
                {
                    GameObject objetoDetectado = PointInfo.collider.gameObject;
                    if (fp.Recogibles == 4)
                    {
                        if (PointInfo.transform.TryGetComponent(out Tent referenciaTent))
                        {
                            fp.Recogibles = 5;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < objetoColeccionable.Length; i++)
                        {
                            if (objetoColeccionable[i] == objetoDetectado)
                            {
                                objetoColeccionable[i].SetActive(false);
                                imagenObjetoInteractuable[i].gameObject.SetActive(true);
                                clonObjetoInteractuable[i].gameObject.SetActive(true);

                                fp.Recogibles++;
                                fp.Vidas+=10;
                                timeCountDown.AnadirTiempo(30);

                                break;
                            }
                        }

                    }
                }
            }
        }
    }
}
