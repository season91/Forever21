using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PropertyEnum
{
    None = 0,
    Passive,
    Spawn,
    Hit,
}

/// <summary>
/// ≈ıªÁ√º delegate
/// </summary>
public class ProjectileProperty
{
    public PropertyEnum PropertyType;
    public delegate void HandlerDelegate(BaseAttackHandler _Handler);
    public delegate void UpdateDelegate(Projectile _Projectile);
    public delegate void CollisionDelegate();
    public HandlerDelegate HandlerFunctions;
    public UpdateDelegate UpdateFunctions;
    public CollisionDelegate CollisionFunctions;

    public virtual void Init()
    {

    }

    public void HanlderExcute(BaseAttackHandler _Handler)
    {
        HandlerFunctions?.Invoke(_Handler);
    }

    public void UpdateExcute(Projectile _Projectile)
    {
        UpdateFunctions?.Invoke(_Projectile);
    }

    public void CollisionExcute() {
        CollisionFunctions?.Invoke();
    }

}
