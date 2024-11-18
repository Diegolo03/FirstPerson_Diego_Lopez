using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
   
    [SerializeField] private GameObject prefabGranada;
    [SerializeField] public Transform spawnPoint; 

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0)) 
        {
           
            Instantiate(prefabGranada, spawnPoint.position, spawnPoint.rotation);
        }
    }
}


