using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCountDown : MonoBehaviour
{
    [SerializeField] private int minutos;
    [SerializeField] private int segundos;
    [SerializeField] private TextMeshProUGUI tiempo;
    [SerializeField] private FirstPerson fp;

    private float resto;
    private bool play;


    private void Awake()
    {
        resto = (minutos * 60) + segundos;
        play = true;

    }


    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            resto -= Time.deltaTime;
            if (resto < 1)
            {
                play = true;
                fp.TiempoFuera = true;
            }
            int tempMinutos = Mathf.FloorToInt(resto / 60);
            int tempSegundos = Mathf.FloorToInt(resto % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", tempMinutos, tempSegundos);

        }

    }
    public void AnadirTiempo(int bonus)
    {
        resto += bonus;
    }
}

