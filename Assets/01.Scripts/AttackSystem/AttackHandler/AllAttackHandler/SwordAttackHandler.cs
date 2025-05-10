using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackHandler : BaseAttackHandler
{
    public override void Init()
    {
        EnumType = AttackHandlerEnum.Sword;

        // ������ ��������
        ProjectilePrefab = ResourceManager.Instance.GetResource<GameObject>("SwordProjectile");

        // �⺻ Stat
        BaseStatus.Damage = 0;
        BaseStatus.SpawnTime = 5;
        BaseStatus.HitCount = 1;
        BaseStatus.ProjectileCount = 1;
        BaseStatus.DestroyTime = 2;
        BaseStatus.Speed = 1;

        CurrentStatus.CopyValue(BaseStatus);
    }
}
