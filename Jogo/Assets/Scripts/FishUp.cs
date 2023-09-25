using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishUp : MonoBehaviour
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
        rb.velocity= new Vector2(rb.velocity.x,velocidade);
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("parede")){
            sprite.flipX=!sprite.flipX;
            velocidade=velocidade*-1;
        }
    }
}
