using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemigo enemigosPrefab;
    [SerializeField] private Transform[] puntosSpawn;
    // Start is called before the first frame update
    void Start()
    {
       

        //Instantiate(enemigosPrefab, puntosSpawn[posicion],Quaternion.identity);
    }

    
}
