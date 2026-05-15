using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool juegoIniciado;
    public int puntaje;
    public Text textoPuntaje;
    public Text textoPuntajeMaximo;

    private void Awake()
    {
        //Obtener puntaje maximo
        textoPuntajeMaximo.text = "Mejor: " + ObtenerPuntajeMaximo().ToString();
    }

    public void IniciarJuego()
    {
        juegoIniciado = true;
        // Iniciar la construcción de la ruta
        FindAnyObjectByType<Ruta>().IniciarConctruccion();
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            IniciarJuego();
        }
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(0);
    }

    public void AumentarPuntaje()
    {
        puntaje++;

        // setear el texto del puntaje en la UI
        textoPuntaje.text = puntaje.ToString();
        ActualizarPuntajeMaximo();
    }

    public int ObtenerPuntajeMaximo()
    {
        // Obtener el puntaje máximo almacenado en PlayerPrefs
        int puntajeMaximo = PlayerPrefs.GetInt("PuntajeMaximo");
        return puntajeMaximo;
    }

    public void ActualizarPuntajeMaximo()
    {
        if (puntaje > ObtenerPuntajeMaximo())
        {
            PlayerPrefs.SetInt("PuntajeMaximo", puntaje);
        }
    }
}
