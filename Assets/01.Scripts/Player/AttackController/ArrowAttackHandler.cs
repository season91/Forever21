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

    }

}
