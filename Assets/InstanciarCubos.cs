using UnityEngine;

public class InstanciarCubos : MonoBehaviour
{

    public Transform prefab;
    int contador = 0;


    // Update is called once per frame
    void Update()
    {
        
    }

    void Start()
    {
        //InvokeRepeating("CrearCuboNuevo", 3f, 1.0f);
        Invoke("CrearCuboNuevo", 3f);
    }

    public void CrearCuboNuevo()
    {
        Instantiate(prefab, new Vector3(-10 + contador * 3.0f, 0, 0), Quaternion.identity);
        contador++;

        if(contador >= 5)
        {
            CancelInvoke("CrearCuboNuevo");
        }
    }
}
