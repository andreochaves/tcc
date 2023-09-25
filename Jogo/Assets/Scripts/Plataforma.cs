using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject Player;
    
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            Player.transform.parent=transform;
        }
    }
    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            Player.transform.parent=null;
        }
    }
}
