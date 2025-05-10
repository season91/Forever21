using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandlerManager : MonoBehaviour
{
    //객체없이 활용할 수 있는 전역 데이터
    private Dictionary<AttackHandlerEnum, BaseAttackHandler> AllAttackHandles
        = new Dictionary<AttackHandlerEnum, BaseAttackHandler>();

    bool IsInit = false;
    public void Init()
    {
        if (IsInit) return;
        IsInit = true;

        AllAttackHandles.Add(AttackHandlerEnum.Arrow, gameObject.AddComponent<ArrowAttackHandler>());
        AllAttackHandles.Add(AttackHandlerEnum.Dager, gameObject.AddComponent<DagerAttackHandler>());
        AllAttackHandles.Add(AttackHandlerEnum.Axe, gameObject.AddComponent<AxeAttackHandler>());
        AllAttackHandles.Add(AttackHandlerEnum.Sword, gameObject.AddComponent<SwordAttackHandler>());
        AllAttackHandles.Add(AttackHandlerEnum.Hammer, gameObject.AddComponent<HammerAttackHandler>());

        foreach (KeyValuePair<AttackHandlerEnum, BaseAttackHandler> pair in AllAttackHandles)
        {
            pair.Value.Init();
        }
    }

    public BaseAttackHandler GetAttackHandle(AttackHandlerEnum attackHandler)
    {
        if (AllAttackHandles.TryGetValue(attackHandler, out BaseAttackHandler value))
        {
            return value;
        }
        return null;
    }

}
