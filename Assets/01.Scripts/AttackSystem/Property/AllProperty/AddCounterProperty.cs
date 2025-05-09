using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCounterProperty : ProjectileProperty
{
    public override void Init()
    {
        base.Init();
        HandlerFunctions = AddHitCounter;
        EnumType = PropertyEnum.Handler;
    }

    int Count = 1;

    public void AddHitCounter(BaseAttackHandler _BaseAttack)
    {
        _BaseAttack.CurrentStatus.Damage = _BaseAttack.CurrentStatus.Damage + Count;
    }

}
