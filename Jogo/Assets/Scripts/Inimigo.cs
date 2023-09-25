using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private float velocidade = 5;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    
    void Start()
    {
        rb=gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.velocity= new Vector2(velocidade,rb.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("parede")){
            sprite.flipX=!sprite.flipX;
            velocidade=velocidade*-1;
        }
    }
    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.CompareTag("Enemy")){
            sprite.flipX=!sprite.flipX;
            velocidade=velocidade*-1;
        }

        if(collider.gameObject.CompareTag("Player")){
            sprite.flipX=!sprite.flipX;
            velocidade=velocidade*-1;
        }
    }
}
