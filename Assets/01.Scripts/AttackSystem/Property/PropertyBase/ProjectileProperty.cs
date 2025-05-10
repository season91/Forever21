using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PropertyEnum
{
    None = 0,
    Handler,
    Update,
    Collision,
}

public class ProjectileProperty
{
    public PropertyEnum EnumType;
    public delegate void HandlerDelegate(BaseAttackHandler _Handler);  // 상수 업그레이드
    public delegate void UpdateDelegate(Projectile _Projectile);  // 상시 업그레이드
    public delegate void CollisionDelegate();   //충돌 업그레이드
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
