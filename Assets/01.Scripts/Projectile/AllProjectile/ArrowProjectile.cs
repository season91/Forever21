using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : Projectile
{
    private void Awake()
    {
        Owner = AttackHandlerEnum.Arrow;
    }


}
