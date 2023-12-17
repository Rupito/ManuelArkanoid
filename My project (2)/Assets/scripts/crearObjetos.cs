using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class crearObjetos : MonoBehaviour
{
    public GameObject poderBarrita;
    public GameObject PoderVida;
    int numeroRandom2;
    int numeroRandom;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D objetoConElQueChoca)
    {
        if (objetoConElQueChoca.gameObject.tag != "cubo")
        {
           
            numeroRandom2 = Random.Range(0, 9);
            if (numeroRandom2 > 4 && numeroRandom2 < 6)
            {
                Instantiate(poderBarrita, transform.position,Quaternion.identity);
            }

            numeroRandom = Random.Range(0, 20);
            if (numeroRandom > 10 && numeroRandom < 13)
            {
                Instantiate(PoderVida, transform.position, Quaternion.identity);
            }
        }
    }
}  
