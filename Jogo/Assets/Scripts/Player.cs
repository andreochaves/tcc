using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    //INT
    int startVida = 100;
    int vidaAtual;
    int amount = 10;

    //GAME OBJECT
    public GameObject quest;
    public GameObject ponto;
    public GameObject pontoPergunta;
    public GameObject pergunta;
    public GameObject player2;
    public GameObject panel;
    public GameObject portal1;
    public GameObject portal2;
    public GameObject chao;

    //CLASSES E OUTROS
    Vector2 respawn;
    public Slider vidaBarra;
    public Animator animacao;
    Rigidbody2D rb;


    //FLOAT
    float forcaPulo = 500;
    float velocidadeMaxima = 3;
    float movimento, movimentov;

    //BOOL
    public bool isGround;
    bool isDead;

    void Start()
    {
        GameManager.gm.AtualizaHud();
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
        vidaAtual = startVida;
        vidaBarra.value = vidaAtual;
        respawn = transform.position;
    }

    void Update()
    {
        movimentov = Input.GetAxis("Vertical");
        vidaBarra.value = vidaAtual;
        Movimento();
        Flip();
        Pulo();
        Vida();
    }

    void Movimento()
    {
        movimento = Input.GetAxis("Horizontal") * velocidadeMaxima;
        rb.velocity = new Vector2(movimento * velocidadeMaxima, rb.velocity.y);
        animacao.SetBool("Run", true);
    }
    void Flip()
    {
        if (movimento < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movimento > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            animacao.SetBool("Run", false);

        }
    }

    void Pulo()
    {
        if (movimentov > 0.5f)
        {
            if (isGround == true)
            {
                animacao.SetBool("Jump", true);
                animacao.SetBool("Run", false);
                isGround = false;
                rb.AddForce(new Vector2(0, forcaPulo));
            }
        }
    }

    void Vida()
    {
        if (vidaAtual <= 0 && !isDead)
        {
            isDead = true;
            Respanw();
        }
    }

    void RespanwPerguntas()
    {
        ponto.SetActive(true);
        quest.SetActive(true);
    }

    void Respanw()
    {
        transform.position = respawn;
        vidaAtual = 100;
        isDead = false;
        string[] algo = ManagerAluno.ma.GetPontuacaoPorFase().Split(',');
        if (algo.Length == (GameManager.gm.Fases))
        {
            RespanwPerguntas();
        }
    }

    IEnumerator PortalTime()
    {
        portal1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Destroy(portal1);
        portal2.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("chao"))
        {
            isGround = true;
            animacao.SetBool("Jump", false);
            rb.gravityScale = 1;
        }

        if (col.gameObject.CompareTag("Enemy"))
        {
            vidaAtual = vidaAtual - amount;
        }

        if (col.gameObject.CompareTag("naoSubir"))
        {
            rb.gravityScale = 1;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Coin"))
        {
            GameManager.gm.SetCoins(10);
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.CompareTag("Enemy"))
        {
            vidaAtual = vidaAtual - amount;
        }

        if (collider.gameObject.CompareTag("Quest"))
        {
            pergunta.SetActive(true);
            pontoPergunta.SetActive(true);
            quest.SetActive(false);
            Time.timeScale = 0;
        }

        if (collider.gameObject.CompareTag("chao"))
        {
            isGround = true;
            animacao.SetBool("Jump", false);
            rb.gravityScale = 1;
        }

        if (collider.gameObject.CompareTag("Live"))
        {
            Destroy(collider.gameObject);
            vidaAtual = 100;
        }

        if (collider.gameObject.CompareTag("Fim"))
        {
            string[] algo = ManagerAluno.ma.GetPontuacaoPorFase().Split(',');
            if (algo.Length < (GameManager.gm.Fases + 1))
            {
                ManagerAluno.ma.SetPontuacao(0);
            }
            player2.SetActive(true);
            gameObject.SetActive(false);
        }

        if (collider.gameObject.CompareTag("checkpoint"))
        {
            respawn = transform.position;
        }

        if (collider.gameObject.CompareTag("Morte"))
        {
            Respanw();
        }

        if (collider.gameObject.CompareTag("EnemyF"))
        {
            vidaAtual = vidaAtual - (amount * 5);
        }

        if (collider.gameObject.CompareTag("pa"))
        {
            StartCoroutine(PortalTime());
        }
    }
}