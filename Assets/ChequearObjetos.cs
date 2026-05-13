using UnityEngine;

public class ChequearObjetos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit tocado;

        if (Physics.Raycast(rayo, out tocado, 100f))
        {
            //print("Chocamos algo :" + tocado.transform.position);
        }
        else
        {
            //print("No tocamos nada");
        }

        //RaycastHit tocado;

        //if(Physics.Raycast(transform.position, -Vector3.up, out tocado, 100f))
        //{
        //    print("Chocamos algo a " + tocado.transform.position);
        //}
        //else
        //{
        //    print("No chocamos nada");
        //}
    }
}
