using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttackHandler : BaseAttackHandler
{
    public override void Init()
    {
        EnumType = AttackHandlerEnum.Hammer;

        // ������ ��������
        ProjectilePrefab = ResourceManager.Instance.GetResource<GameObject>("HammerProjectile");

        // �⺻ Stat
        BaseStatus.Damage = 0;
        BaseStatus.SpawnTime = 4;
        BaseStatus.HitCount = 1;
        BaseStatus.ProjectileCount = 1;
        BaseStatus.DestroyTime = 2;
        BaseStatus.Speed = 3;

        CurrentStatus.CopyValue(BaseStatus);
    }
}
