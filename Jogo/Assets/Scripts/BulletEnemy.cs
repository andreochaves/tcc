using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    
    private float velocidade =25;
    private Vector2 direcao;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity=direcao*velocidade;
        direcao = Vector2.left;
    }

    
    
    public void Inicializar(Vector2 _direcao)
    {
        direcao = _direcao;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("parede")){
            Destroy(gameObject);
        }

        if(collider.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
