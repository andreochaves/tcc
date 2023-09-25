using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIgloo : MonoBehaviour
{
    public Transform pontoBala;
    public GameObject Bala;

    public SpriteRenderer enemy;

    public void Acao()
    {
        GameObject tmpBala = Instantiate(Bala,pontoBala.position,Quaternion.identity);
        tmpBala.GetComponent<BulletEnemy>().Inicializar(Vector2.left);
    }
}
