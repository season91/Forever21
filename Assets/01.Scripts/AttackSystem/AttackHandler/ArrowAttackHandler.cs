using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttackHandler: BaseAttackHandler
{
    public override void Init()
    {
        EnumType = AttackHandlerEnum.Arrow;
        BaseAttackHandler.AllAttackHandles[EnumType] = this;

        ProjectilePrefab = ResourceManager.Instance.GetResource<GameObject>("ArrowProjectile");


        BaseStatus.Damage = 0;
        BaseStatus.SpawnTime = 2;
        BaseStatus.HitCount = 1;
        BaseStatus.ProjectileCount = 1;
        BaseStatus.DestroyTime = 5;
        BaseStatus.Speed = 5;

        CurrentStatus.CopyValue(BaseStatus);
    }

}
