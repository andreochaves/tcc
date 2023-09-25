using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Sprite redFlag;
    public Sprite greenFlag;
    private SpriteRenderer checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        checkpoint=GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag=="Player"){
            checkpoint.sprite=greenFlag;
        }
    }
}
