using UnityEngine;

public class GuardarInformacion : MonoBehaviour
{

    int numero = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //print("El numero guardado es: " + ObtenerNumero());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            numero++;
            if(numero > ObtenerNumero())
            {
                PlayerPrefs.SetInt("MiNumero", numero);
                //print(numero);
            }
        }    
    }

    int ObtenerNumero()
    {
        int miNumero = PlayerPrefs.GetInt("MiNumero", 0) ;
        return miNumero;
    }
     
}
