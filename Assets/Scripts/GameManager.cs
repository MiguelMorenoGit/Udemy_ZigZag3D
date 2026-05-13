using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool juegoIniciado;

    public void IniciarJuego()
    {
        juegoIniciado = true;
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
}
