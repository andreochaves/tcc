using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float velocidade = 5;
    Rigidbody2D rb;
    public Animator animacao;
    public GameObject portal1, portal2, portal3, camera2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(velocidade, rb.velocity.y);
        animacao.SetBool("Run", true);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("p1"))
        {
            portal1.SetActive(true);
        }

        if (collider.gameObject.CompareTag("p2"))
        {
            portal2.SetActive(true);
            portal1.SetActive(false);
        }

        if (collider.gameObject.CompareTag("portal"))
        {
            portal3.SetActive(true);
            portal2.SetActive(false);
            gameObject.SetActive(false);
            camera2.SetActive(true);
            GameManager.gm.SetFases(1);
        }
    }
}