using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
   
    // Variables serializadas
    [SerializeField] private int indiceArmaActual = 0; // Índice del arma actualmente equipada.
    [SerializeField] private GameObject[] armas; // Arreglo de armas configurado desde el Inspector.

    // Método que se llama en cada frame.
    void Update()
    {
        CambiarArmaConTeclado();
        CambiarArmaConRaton();
    }

    // Cambiar arma con la rueda del ratón.
    private void CambiarArmaConRaton()
    {
        // Lectura de la rueda del ratón (subir y bajar).
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheel > 0) // Cambiar al arma anterior.
        {
            CambiarArma(indiceArmaActual - 1);
        }
        else if (scrollWheel < 0) // Cambiar al arma siguiente.
        {
            CambiarArma(indiceArmaActual + 1);
        }
    }

    // Cambiar arma con el teclado.
    private void CambiarArmaConTeclado()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambiarArma(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            CambiarArma(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            CambiarArma(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            CambiarArma(3);
        }
    }

    // Lógica para cambiar el arma.
    private void CambiarArma(int nuevoIndice)
    {
        // Validar que el índice es válido.
        if (nuevoIndice >= 0 && nuevoIndice < armas.Length)
        {
            // Desactivar el arma actualmente equipada.
            armas[indiceArmaActual].SetActive(false);

            // Cambiar el índice actual.
            indiceArmaActual = nuevoIndice;

            // Activar la nueva arma.
            armas[indiceArmaActual].SetActive(true);
        }
    }
}


