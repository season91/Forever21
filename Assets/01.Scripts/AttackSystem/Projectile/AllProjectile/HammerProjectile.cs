using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerProjectile : Projectile
{
    private void Awake()
    {
        Owner = AttackHandlerEnum.Hammer;
    }
}
