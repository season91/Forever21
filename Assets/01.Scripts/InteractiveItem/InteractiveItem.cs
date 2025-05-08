using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D boxColider2D;
    SpriteRenderer spriteRenderer;

    delegate void OnCollisionEnter(Collider2D other);

    OnCollisionEnter onCollisionEnter;

    private void Reset()
    {
        boxColider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == StringClass.Player)
        {
            onCollisionEnter(collision);
        }   
    }



}
