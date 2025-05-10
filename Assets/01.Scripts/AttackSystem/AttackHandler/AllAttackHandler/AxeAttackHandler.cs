using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttackHandler : BaseAttackHandler
{
    public override void Init()
    {
        EnumType = AttackHandlerEnum.Axe;

        // 프리팹 가져오기
        ProjectilePrefab = ResourceManager.Instance.GetResource<GameObject>("AxeProjectile");

        // 기본 Stat
        BaseStatus.Damage = 0;
        BaseStatus.SpawnTime = 4;
        BaseStatus.HitCount = 1;
        BaseStatus.ProjectileCount = 1;
        BaseStatus.DestroyTime = 2;
        BaseStatus.Speed = 7;

        CurrentStatus.CopyValue(BaseStatus);
    }
}
