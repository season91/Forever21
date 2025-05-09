using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    Dictionary<AttackHandlerEnum, BaseAttackHandler> AttackDictionary;

    private void Awake()
    {
        AttackDictionary = new Dictionary<AttackHandlerEnum, BaseAttackHandler>();
        AttackDictionary.Add(AttackHandlerEnum.Arrow, gameObject.AddComponent<ArrowAttackHandler>());
    }

    bool IsInit = false;
    public void Init()
    {
        if (IsInit == true) return;
        IsInit = true;
        foreach (KeyValuePair<AttackHandlerEnum, BaseAttackHandler> Pair in AttackDictionary)
        {
            Pair.Value.Init();
        }
    }


    public void AddProperty(AttackHandlerEnum _AttackHandlerEnum, ProjectileProperty _Property)
    {
        AttackDictionary[_AttackHandlerEnum].AddProperty(_Property);
    }

    public void Attack()
    {
#if UNITY_EDITOR
        if (IsInit == false)
        {
            Debug.Log("PlayerAttackSystem Initialize is not work");
        }
#endif

        foreach (KeyValuePair<AttackHandlerEnum, BaseAttackHandler> Pair in AttackDictionary)
        {
            Pair.Value.Attack();
        }
    }
}
