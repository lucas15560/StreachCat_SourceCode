using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siri : MonoBehaviour
{
    public bool Tocar;
    public float Velocity;
    public float Lado;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(Tocar == false)
        {
            Vire();
        }

        if (Tocar)
        {
            rb.velocity = new Vector3(Lado * Velocity, 0f, 0f);
        }
    }

    void Vire()
    {
        Lado = Lado * -1;
        Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        transform.localScale = novoScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Tocar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Tocar = false;
        }
    }

}
