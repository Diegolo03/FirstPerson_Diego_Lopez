using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCountDown : MonoBehaviour
{
    [SerializeField] int minutos;
    [SerializeField] int segundos;
    [SerializeField] TextMeshProUGUI tiempo;
    [SerializeField] FirstPerson fp;

    float resto;
    bool play;


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
}

