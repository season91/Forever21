using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ≈ıªÁ√º
/// </summary>
public class Projectile : MonoBehaviour
{
    List<ProjectileProperty> SpawnFunctions;
    List<ProjectileProperty> PassiveFunctions;
    List<ProjectileProperty> CollisionFunctions;

    public int HitCount = 1;

    [SerializeField] SpriteRenderer spriterenderer;

    [SerializeField] BoxCollider2D collision2D;

    private void Awake()
    {
        collision2D = GetComponent<BoxCollider2D>();
    }


    public void Spawn()
    {
        foreach(ProjectileProperty Property in SpawnFunctions)
        {
            Property.Excute(this);
        }
    }

    private void Update()
    {
        foreach (ProjectileProperty Property in PassiveFunctions)
        {
            Property.Excute(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(StringClass.Monster))
        {
            foreach (ProjectileProperty Property in CollisionFunctions)
            {
                Property.Excute(this);
            }

            --HitCount;
            if (HitCount == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
