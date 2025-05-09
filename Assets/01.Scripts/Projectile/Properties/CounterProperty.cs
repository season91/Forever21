using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterProperty : ProjectileProperty
{
    public override void Init()
    {
        base.Init();
        HandlerFunctions = AddHitCounter;
    }

    int Count = 1;

    public void AddHitCounter(BaseAttackHandler _BaseAttack)
    {
        _BaseAttack.CurrentStatus.HitCount += Count;
    }
    
}
