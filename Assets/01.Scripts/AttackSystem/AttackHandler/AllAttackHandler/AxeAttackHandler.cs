using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttackHandler : BaseAttackHandler
{
    public override void Init()
    {
        EnumType = AttackHandlerEnum.Axe;

        // ������ ��������
        ProjectilePrefab = ResourceManager.Instance.GetResource<GameObject>("AxeProjectile");

        // �⺻ Stat
        BaseStatus.Damage = 0;
        BaseStatus.SpawnTime = 4;
        BaseStatus.HitCount = 1;
        BaseStatus.ProjectileCount = 1;
        BaseStatus.DestroyTime = 2;
        BaseStatus.Speed = 7;

        CurrentStatus.CopyValue(BaseStatus);
    }
}
