using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ItemType
{
    None = 0,
    Exp,
    Heal,
    Functional,
}

public class InteractiveItem : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D boxColider2D;
    SpriteRenderer spriteRenderer;

    protected delegate void OnCollisionEnter();

    protected OnCollisionEnter onCollisionEnter;

    private void Reset()
    {
        boxColider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(StringClass.Player) == true)
        {
            onCollisionEnter();
            gameObject.SetActive(false);
        }   
    }
}
