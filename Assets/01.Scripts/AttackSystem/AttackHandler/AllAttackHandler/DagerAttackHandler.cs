using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagerAttackHandler : BaseAttackHandler
{

    public override void Init()
    {
        EnumType = AttackHandlerEnum.Dager;
        //BaseAttackHandler.AllAttackHandles[AttackHandlerEnum.Dager] = this; // 모든 무기에 값

        // 프리팹 가져오기
        ProjectilePrefab = ResourceManager.Instance.GetResource<GameObject>("DagerProjectile");

        // 기본 Stat
        BaseStatus.Damage = 0;
        BaseStatus.SpawnTime = 3;
        BaseStatus.HitCount = 1;
        BaseStatus.ProjectileCount = 1;
        BaseStatus.DestroyTime = 2;
        BaseStatus.Speed = 6;

        CurrentStatus.CopyValue(BaseStatus);
    }
}
