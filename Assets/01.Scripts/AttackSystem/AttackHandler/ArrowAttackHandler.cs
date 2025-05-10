using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ӽ÷� �����ִ� ���� �ڵ鷯 << ����
/// </summary>
public class ArrowAttackHandler: BaseAttackHandler
{
    public override void Init()
    {
        EnumType = AttackHandlerEnum.Arrow;
        BaseAttackHandler.AllAttackHandles[EnumType] = this; // <<< ???


        ProjectilePrefab = ResourceManager.Instance.GetResource<GameObject>("ArrowProjectile");


        //�ܰ�, Ȱ, ���� ����� ���� ������ �޶���Ѵ�.
        //base status
        //8�������ϸ� arrow attack handler�����Ÿ� 8�� ��������
        BaseStatus.Damage = 0;
        BaseStatus.SpawnTime = 2;
        BaseStatus.HitCount = 1;
        BaseStatus.ProjectileCount = 1;
        BaseStatus.DestroyTime = 5;
        BaseStatus.Speed = 5;

        //���Ⱑ ���ݷ��� ���׷��̵� �ȴٰ� �غ���
        //base������� ���� ���ݷ��� �ö󰡾���
        CurrentStatus.CopyValue(BaseStatus);
    }

}
