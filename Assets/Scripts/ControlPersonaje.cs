using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{

    private Rigidbody rb;
    private bool caminarDerecha = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CambiarDireccion();
        }
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * 2 * Time.deltaTime);
    }

    private void CambiarDireccion()
    {

    }
}
