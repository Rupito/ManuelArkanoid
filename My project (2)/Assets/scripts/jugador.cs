using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class jugador : MonoBehaviour
{
    float segundos;
    float velocidad;  
    
    void Start()
    {
        segundos = 0f;

        velocidad = 11.0f;
    }

  
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(velocidad * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(velocidad * Time.deltaTime, 0f, 0f);
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.tag == "barritaPoder")
        {
            Destroy(collision.gameObject);
            transform.localScale = new Vector3(0.4448788f, 0.7174034f, 0f);

            InvokeRepeating("contar", 0f, 1f);
        }

        if (collision.gameObject.tag == "vidapoder")
        {
            pelota.contarvidas += 1;
            Destroy(collision.gameObject);
        }
    }
    
    
    void contar()
    {
        segundos++;
        if (segundos == 10f)
        {
            CancelInvoke("contar");
            Debug.Log("se terminó el tiempo del poder");
            segundos = 0f;
            transform.localScale = new Vector3(1.2067f, 1.1152f, 0f);

        }
    }
}
