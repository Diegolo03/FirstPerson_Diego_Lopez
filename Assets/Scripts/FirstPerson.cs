using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {

        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
       float h= Input.GetAxisRaw("Horizontal");
       float v= Input.GetAxisRaw("Vertical");
        

    }
}