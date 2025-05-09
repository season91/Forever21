using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStatus
{
    public int Damage;  //뎀지
    public int DestroyTime;  //언제 비활성화
    public int HitCount;  //몇 번 충돌해야 사라지나
    public int ProjectileCount;  //몇 개 스폰할거냐
    public float SpawnTime;  // 쿨타임
    public int Speed;

    public void CopyValue(ProjectileStatus _Status)
    {
        Damage = _Status.Damage;
        DestroyTime = _Status.DestroyTime;
        HitCount = _Status.HitCount;
        ProjectileCount = _Status.ProjectileCount;
        SpawnTime = _Status.SpawnTime;
        Speed = _Status.Speed;
    }
}
