using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStatus
{
    public int Damage;  //����
    public int DestroyTime;  //���� ��Ȱ��ȭ
    public int HitCount;  //�� �� �浹�ؾ� �������
    public int ProjectileCount;  //�� �� �����Ұų�
    public float SpawnTime;  // ��Ÿ��
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
