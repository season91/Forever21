using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    protected List<IInitializeInterface> InitList = new List<IInitializeInterface>();


    public delegate void DeadFunction();
    protected DeadFunction OnDead;
    [SerializeField] protected BoxCollider2D EntityCollision;
    [SerializeField] protected Rigidbody2D EntityRigidbody;

    protected EntityStatus status;
    protected AIController controller;

    protected void Reset()
    {
        EntityCollision = GetComponent<BoxCollider2D>();
        EntityRigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Init()
    {
        foreach (IInitializeInterface element in InitList)
        {
            element.Init();
        }
    }
    private void Update()
    {
        foreach (IInitializeInterface element in InitList)
        {
            element.InitUpdate();
        }
    }

    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        EntityRigidbody.velocity = controller.Direction * status.Speed;
    }

    public void TakeDamage(int amount)
    {
        status.TakeDamage(amount);
    }

    protected void OnDestroy()
    {
        OnDead.Invoke();
    }
}
