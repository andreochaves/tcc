using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variados : MonoBehaviour
{
    public EnemyIgloo gatilho;
    public EnemyIgloo gatilho1;
    void OnTriggerEnter2D (Collider2D collider){
        if(collider.gameObject.CompareTag("p1")){
            gatilho.Acao();
        }

        if(collider.gameObject.CompareTag("p2")){
            gatilho1.Acao();
        }
    }
}
