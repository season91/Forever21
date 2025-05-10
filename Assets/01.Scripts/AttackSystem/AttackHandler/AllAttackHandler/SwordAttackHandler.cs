using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackHandler : BaseAttackHandler
{
    public override void Init()
    {
        EnumType = AttackHandlerEnum.Sword;

        // 프리팹 가져오기
        ProjectilePrefab = ResourceManager.Instance.GetResource<GameObject>("SwordProjectile");

        // 기본 Stat
        BaseStatus.Damage = 0;
        BaseStatus.SpawnTime = 5;
        BaseStatus.HitCount = 1;
        BaseStatus.ProjectileCount = 1;
        BaseStatus.DestroyTime = 2;
        BaseStatus.Speed = 1;

        CurrentStatus.CopyValue(BaseStatus);
    }
}
