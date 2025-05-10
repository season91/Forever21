using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjectile : Projectile
{
    private void Awake()
    {
        Owner = AttackHandlerEnum.Sword;
    }
}
