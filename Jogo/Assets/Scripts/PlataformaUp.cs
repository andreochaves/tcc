using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaUp : MonoBehaviour
{
    public GameObject Player;
    private float velocidade = 3;
    Rigidbody2D rb;
    SpriteRenderer sprite;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, velocidade);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("parede"))
        {
            velocidade = velocidade * -1;
        }

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("parede"))
        {
            velocidade = velocidade * -1;
        }

        // if (collider.gameObject.CompareTag("Player"))
        // {
        //     Player.transform.parent = this.transform;
        // }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Player.transform.parent = null;
            rb.velocity = new Vector2(0,0);
        }
    }
}
