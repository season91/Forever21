using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EntityStatus : IInitializeInterface
{
    [Header("체력")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    private bool isDead = false;

    [Header("레벨")]
    //[SerializeField] private float expGrowthRate = 1.2f;

    [Header("속도")]
    [HideInInspector] public float Speed = 1.0f;

    bool IsInit = false;
    public void Init()
    {
        if (IsInit == true) return;
        
    }

    public void InitUpdate()
    {

    }

    public bool TakeDamage(int amount)  //플레이어가 데미지 받을 때 호출되는 함수
    {
        if (isDead == true) return false;

        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth <= 0)
        {
            return true;
        }
        return false;
    }

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
}
