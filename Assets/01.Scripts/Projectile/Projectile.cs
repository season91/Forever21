using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ≈ıªÁ√º
/// </summary>
public class Projectile : MonoBehaviour
{

    protected AttackHandlerEnum Owner;

    ProjectileStatus projectileStatus;

    [SerializeField] SpriteRenderer spriterenderer;

    [SerializeField] BoxCollider2D collision2D;

    private void Awake()
    {
        collision2D = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        projectileStatus = BaseAttack.AllAttackHandles[Owner].CurrentStatus;
    }

    private void OnEnable()
    {
        projectileStatus = BaseAttack.AllAttackHandles[Owner].CurrentStatus;
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
