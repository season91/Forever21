using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 임시로 갖고있는 공격 핸들러 << 현재
/// </summary>
public class ArrowAttackHandler: BaseAttackHandler
{
    public override void Init()
    {
        EnumType = AttackHandlerEnum.Arrow;
        BaseAttackHandler.AllAttackHandles[EnumType] = this; // <<< ???


        ProjectilePrefab = ResourceManager.Instance.GetResource<GameObject>("ArrowProjectile");


        //단검, 활, 도끼 등등은 무기 스텟이 달라야한다.
        //base status
        //8가지라하면 arrow attack handler같은거를 8개 만들어야함
        BaseStatus.Damage = 0;
        BaseStatus.SpawnTime = 2;
        BaseStatus.HitCount = 1;
        BaseStatus.ProjectileCount = 1;
        BaseStatus.DestroyTime = 5;
        BaseStatus.Speed = 5;

        //무기가 공격력이 업그레이드 된다고 해봐요
        //base기반으로 무기 공격력이 올라가야함
        CurrentStatus.CopyValue(BaseStatus);
    }

}
