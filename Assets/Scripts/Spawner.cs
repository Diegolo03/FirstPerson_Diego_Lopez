using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private Enemigo enemigoPrefab, osoprefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnearEnemigos());
    }

    private IEnumerator SpawnearEnemigos()
    {
        while (true)
        {
            Enemigo enemigoCopia = Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
            Enemigo OsoCopia = Instantiate(osoprefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(10);

        }
    }
}
