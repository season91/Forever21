using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagerProjectile : Projectile
{
    private void Awake()
    {
        Owner = AttackHandlerEnum.Dager;
    }
}
