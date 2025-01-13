using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstPerson: MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float vidas;
    [SerializeField] private float porcentajeVida;
    private CharacterController cc;
    private Camera cam;

    [Header("Configuración Gravedad")]
    [SerializeField] private Vector3 movimientoVertical;
    [SerializeField] private float escalaGravedad;
    [SerializeField] private float alturaSalto = 3f;
    [SerializeField] private Transform pies;
    [SerializeField] private float radioDeteccion = 0.3f;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private bool tiempoFuera = false;
    [SerializeField] private int recogibles;
    [SerializeField] private Image barraDeVida;

    public float Vidas { get => vidas; set => vidas = value; }
    public int Recogibles { get => recogibles; set => recogibles = value; }
    public bool TiempoFuera { get => tiempoFuera; set => tiempoFuera = value; }



    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {

        porcentajeVida = (Vidas / 100); 
        barraDeVida.fillAmount = porcentajeVida;
        if (TiempoFuera||vidas==0)
        {
            TiempoFuera = false;
            SceneManager.LoadScene(3);
        }
        if (recogibles==5)
        {
            
            SceneManager.LoadScene(2);
        }
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;
        transform.rotation = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);

        if (input.sqrMagnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
            cc.Move((movimiento * velocidadMovimiento) * Time.deltaTime);
        }

        AplicarGravedad();
        DeteccionSuelo();

    }
    private void AplicarGravedad()
    {
        movimientoVertical.y += escalaGravedad * Time.deltaTime;
        cc.Move(movimientoVertical * Time.deltaTime);
    }

    private void DeteccionSuelo()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(pies.position, radioDeteccion, queEsSuelo);
        if (collsDetectados.Length > 0)
        {
            movimientoVertical.y = 0;
            Saltar();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(pies.position, radioDeteccion);
    }
    public void RecibirDano(float danorecibido)
    {
        vidas-=danorecibido;
        if (vidas < 0)
        {
            Destroy(gameObject);
        }
    }


    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2 * escalaGravedad * alturaSalto);
        }
    }
}
