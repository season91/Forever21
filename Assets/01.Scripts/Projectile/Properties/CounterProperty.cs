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

    public void AddHitCounter(BaseAttack _BaseAttack)
    {
        ++_BaseAttack.CurrentStatus.HitCount;
    }
    
}
