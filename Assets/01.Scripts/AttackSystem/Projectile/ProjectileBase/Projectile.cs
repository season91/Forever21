using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ≈ıªÁ√º
/// </summary>
public class Projectile : MonoBehaviour
{

    protected AttackHandlerEnum Owner;

    protected ProjectileStatus projectileStatus = new ProjectileStatus();

    [SerializeField] protected SpriteRenderer spriterenderer;

    [SerializeField] protected BoxCollider2D collision2D;

    [SerializeField] protected Rigidbody2D _rigidbody2D;

    public Vector2 Direction;

    private void Reset()
    {
        collision2D = GetComponent<BoxCollider2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        projectileStatus.CopyValue(BaseAttackHandler.AllAttackHandles[Owner].CurrentStatus);
        transform.rotation = Player.Instance.transform.rotation;
        Direction = transform.up;
    }



    private void FixedUpdate()
    {
        _rigidbody2D.velocity = Direction * projectileStatus.Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(StringClass.Monster))
        {
            --projectileStatus.HitCount;
            if (projectileStatus.HitCount == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
