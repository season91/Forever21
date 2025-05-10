using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagerAttackHandler : BaseAttackHandler
{

    public override void Init()
    {
        EnumType = AttackHandlerEnum.Dager;
        //BaseAttackHandler.AllAttackHandles[AttackHandlerEnum.Dager] = this; // ��� ���⿡ ��

        // ������ ��������
        ProjectilePrefab = ResourceManager.Instance.GetResource<GameObject>("DagerProjectile");

        // �⺻ Stat
        BaseStatus.Damage = 0;
        BaseStatus.SpawnTime = 3;
        BaseStatus.HitCount = 1;
        BaseStatus.ProjectileCount = 1;
        BaseStatus.DestroyTime = 2;
        BaseStatus.Speed = 6;

        CurrentStatus.CopyValue(BaseStatus);
    }
}
