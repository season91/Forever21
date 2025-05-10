using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeProjectile : Projectile
{
    private void Awake()
    {
        Owner = AttackHandlerEnum.Axe;
    }

}
