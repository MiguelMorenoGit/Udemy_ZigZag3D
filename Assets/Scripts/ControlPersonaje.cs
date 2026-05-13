using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{

    public float velocidad = 5f;
    private Rigidbody rb;
    private bool caminarDerecha = true;

    
    public Transform comienzoRayo; // El punto desde donde se lanzará el rayo para detectar el suelo
    private Animator animator; // Referencia al componente Animator

    private GameManager gameManager; // Referencia al GameManager

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameManager = Object.FindAnyObjectByType<GameManager>(); // Encuentra una instancia del GameManager en la escena
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CambiarDireccion();
        }

        RaycastHit contacto;

        if(!Physics.Raycast(comienzoRayo.position, -comienzoRayo.transform.up, out contacto, Mathf.Infinity))
        {
            // Si el rayo no detecta ningún contacto con el suelo, el personaje está en el aire
            animator.SetTrigger("Cayendo");
            //print("Cayendo");
            
        }

        if(transform.position.y < -3)
        {
            gameManager.ReiniciarJuego();
        }
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    private void FixedUpdate()
    {
        if (gameManager.juegoIniciado == false) return;
        else animator.SetTrigger("ComenzoJuego");

        MoverPlayer();

    }

    private void MoverPlayer()
    {
        rb.MovePosition(transform.position + transform.forward * velocidad * Time.deltaTime);
    }

    private void CambiarDireccion()
    {
        caminarDerecha = !caminarDerecha;

        // Cambia la rotación del personaje para que camine en la dirección opuesta
        if (caminarDerecha) rb.MoveRotation(Quaternion.Euler(0, 45, 0));
        else rb.MoveRotation(Quaternion.Euler(0, -45, 0));
    }
}
