using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class pelota : MonoBehaviour
{
    Rigidbody2D rb2d;
    public TextMeshProUGUI vidas;
    public TextMeshProUGUI puntos;
    public static int contarvidas;
    int contarpuntos;
    public Transform barrita;

    bool EnElAire;

    float velocidad;

    void Start()
    {
        velocidad = 11.0f;
        

        rb2d = GetComponent<Rigidbody2D>();

        contarvidas = 3;
        vidas.text = contarvidas.ToString();

        contarpuntos = 0;
        puntos.text = contarpuntos.ToString();

 
        EnElAire = false;
    }



    void Update()
    {
        vidas.text = contarvidas.ToString();

        if (EnElAire == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.WakeUp();
                rb2d.AddForce(new Vector2(6f, 6f), ForceMode2D.Impulse);

                transform.parent = null;
                EnElAire=true;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position -= new Vector3(velocidad * Time.deltaTime, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(velocidad * Time.deltaTime, 0f, 0f);
            }
        }
    }




    private void OnCollisionEnter2D(Collision2D objetoConElQueChoca)
    {

        if (objetoConElQueChoca.gameObject.tag != "cubo")
        {
            Destroy(objetoConElQueChoca.gameObject);
        }

        //====================================================================
        if (objetoConElQueChoca.gameObject.name == "suelo")
        {
            EnElAire = false;

            barrita.transform.position = new Vector3(0f, -4.0736f, 0f);

            contarvidas -= 1;
            vidas.text = contarvidas.ToString();

            transform.position = new Vector3(0f, -3.58f, 0f);
            transform.SetParent(null);
            rb2d.Sleep();

            if (contarvidas == 0)                                                 //vidas
            {
                Debug.Log("GAME OVER");

                contarvidas = 3;
                vidas.text = contarvidas.ToString();

                SceneManager.LoadScene("SampleScene"); //vuelve a carga la escena
            }
        }
        //====================================================================



        //====================================================================
        if (objetoConElQueChoca.gameObject.tag == "cuadrosverdes")
        {

            contarpuntos += 2;
            puntos.text = contarpuntos.ToString();
        }

        if (objetoConElQueChoca.gameObject.tag == "cuadrosamarillos")
        {
            contarpuntos += 5;
            puntos.text = contarpuntos.ToString();
        }

        if (objetoConElQueChoca.gameObject.tag == "cuadrosmorados")              //puntos
        {
            contarpuntos += 10;
            puntos.text = contarpuntos.ToString();
        }

        if (objetoConElQueChoca.gameObject.tag == "cuadrosazules")
        {
            contarpuntos += 15;
            puntos.text = contarpuntos.ToString();
        }

        if (objetoConElQueChoca.gameObject.tag == "cuadrosmarrones")
        {
            contarpuntos += 20;
            puntos.text = contarpuntos.ToString();
        }
        //====================================================================

        if (contarpuntos == 260)
        {
            Debug.Log("Has GANADO!");

            SceneManager.LoadScene("SampleScene"); //vuelve a carga la escena
        }
    }
}
