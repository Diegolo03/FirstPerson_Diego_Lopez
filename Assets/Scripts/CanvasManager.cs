using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public void IniciarPartida()
    {
        SceneManager.LoadScene(1);
    }
    public void FinPartida()
    {
        Application.Quit();
    }
    public void Respawn()
    {
        SceneManager.LoadScene(1);
    }
}
