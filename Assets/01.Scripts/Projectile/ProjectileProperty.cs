using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PropertyEnum
{
    None = 0,
    Passive,
    Spawn,
    Hit,
}

/// <summary>
/// ≈ıªÁ√º delegate
/// </summary>
public class ProjectileProperty
{
    public delegate void PropertyDelegate(Projectile _projectile);
    public PropertyDelegate Functions;

    public virtual void Init()
    {

    }
    public void Excute(Projectile _projectile)
    {
        Functions?.Invoke(_projectile);
    }
}
