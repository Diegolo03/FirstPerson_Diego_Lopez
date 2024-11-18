using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Granada : MonoBehaviour
{
    [SerializeField] private float fuerzaImpulso = 10f; 
    [SerializeField] private float tiempoDeVida = 5f; 
    [SerializeField] float explosionRadius = 5f; 
    [SerializeField] float explosionDamage = 50f;
    [SerializeField] GameObject prefabExplosion;
    [SerializeField] LayerMask damageableLayer;
    private Rigidbody rb;

    void Start()
    {
        // Obtener el Rigidbody del objeto.
        

       
        GetComponent<Rigidbody>().AddForce(transform.forward * fuerzaImpulso, ForceMode.Impulse);
                
        Destroy(gameObject, tiempoDeVida);
    }
    private void OnDestroy()
    {
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius, damageableLayer);
        if (hitColliders.Length > 0)
        {

           foreach (Collider collider in hitColliders)
            {
                collider.GetComponent<ParteDeEnemigo>().Explotar();
                collider.GetComponent<Rigidbody>().isKinematic = false;
                collider.GetComponent<Rigidbody>().AddExplosionForce(explosionDamage, transform.position, explosionRadius);
            }

        }
    }

}
