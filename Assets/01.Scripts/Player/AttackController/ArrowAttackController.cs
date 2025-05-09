using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttackController : BaseAttack
{
    public override void Init()
    {
        ProjectilePrefab = ResourceManager.Instance.GetResource<GameObject>("ArrowProjectile");
    }

}
