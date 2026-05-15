using UnityEngine;

public class Ruta : MonoBehaviour
{

    public GameObject prefabRuta;
    public Vector3 ultimaPosicion;
    public float diferencia = 0.7071068f;

    [SerializeField] private int minBloquesParaGema = 5;
    [SerializeField] private int maxBloquesParaGema = 12;
    private int bloquesParaGema;
    private int cuentaRuta = 0;

    public void IniciarConctruccion()
    {
        InvokeRepeating("CrearNuevaParteRuta", 1f, 0.3f);
        bloquesParaGema = Random.Range(minBloquesParaGema, maxBloquesParaGema + 1);
    }

    public void CrearNuevaParteRuta()
    {

        // Generar un número aleatorio entre 0 y 100
        // para decidir la dirección de la nueva parte de la ruta.
        Vector3 nuevaPosicion = Vector3.zero;
        float opcion = Random.Range(0, 100);

        // Si el número es menor a 50,
        // la nueva parte de la ruta se colocará a la derecha de la última posición.
        if (opcion < 50)
        {
            nuevaPosicion = 
                new Vector3(ultimaPosicion.x + diferencia, ultimaPosicion.y, 
                ultimaPosicion.z + diferencia);
        }
        else
        {
            nuevaPosicion = 
                new Vector3(ultimaPosicion.x - diferencia, ultimaPosicion.y, 
                ultimaPosicion.z + diferencia);
        }

        GameObject nuevaPiezaRuta = 
            Instantiate(prefabRuta, nuevaPosicion, Quaternion.Euler(0,45,0));

        ultimaPosicion = nuevaPiezaRuta.transform.position;

        cuentaRuta++;

        if(cuentaRuta == bloquesParaGema)
        {
            nuevaPiezaRuta.transform.GetChild(0).gameObject.SetActive(true);

            cuentaRuta = 0;
            bloquesParaGema = Random.Range(minBloquesParaGema, maxBloquesParaGema + 1);
        }

    }
}
