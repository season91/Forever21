using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterProperty : ProjectileProperty
{
    public override void Init()
    {
        base.Init();
        Functions = AddHitCounter;
    }

    public void AddHitCounter(Projectile _projectile)
    {
        _projectile.HitCount += 1;
    }
    
}
