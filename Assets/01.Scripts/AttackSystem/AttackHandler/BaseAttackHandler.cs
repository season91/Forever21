using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackHandlerEnum
{
    Arrow = 0,
    Dager = 1,
}

public class BaseAttackHandler : MonoBehaviour
{
    protected GameObject ProjectilePrefab;

    protected AttackHandlerEnum EnumType;



    public ProjectileStatus BaseStatus = new ProjectileStatus();

    public ProjectileStatus CurrentStatus = new ProjectileStatus();

    //Ȱ, Ȱ�� �� Ư���� list 
    public Dictionary<PropertyEnum, List<ProjectileProperty>> Functions = new Dictionary<PropertyEnum, List<ProjectileProperty>>();

    public void AddProperty(ProjectileProperty _property) 
    {
        if (_property == null) return;

        if (!Functions.ContainsKey(_property.EnumType))
        {
            Functions[_property.EnumType] = new List<ProjectileProperty>();  // ������ ����Ʈ Ÿ������ �ʱ�ȭ
        }
        Functions[_property.EnumType].Add(_property);

        switch (_property.EnumType)
        {
            case PropertyEnum.None:
                break;
            case PropertyEnum.Handler:
                HandlerUpdate();
                break;
            case PropertyEnum.Update:
                PassiveUpdate();
                break;
            case PropertyEnum.Collision:
                CollisionUpdate();
                break;
            default:
                break;
        }

    }

    public virtual void Init()
    {

    }

    public void PassiveUpdate()
    {

    }

    public void CollisionUpdate()
    {
        //�浹 �� �۵��� �Լ�
    }

    public void HandlerUpdate()  // ���ݷ� �̳� ������ ���� �����ϴ� �װŶ��ߧc?
    {
        foreach(ProjectileProperty property in Functions[PropertyEnum.Handler])
        {
            //���� ������ ���׷��̵� �ɰǵ�, �ϴ� �ʱⰪ���� ���� �� ���׷��̵带 �մϴ�.
            //���ݷ��� 10�ε�  + 5
            //11�� �ö���ϴµ� base�� 5�����
            // 16

            CurrentStatus.CopyValue(BaseStatus);
            property.HandlerFunctions(this);
        }
    }

    public virtual void AllReset()
    {

    }


    public virtual void Attack()
    {
        if(CurrentStatus.SpawnTime < 0f)
        {
            // object pool�� Get���� �����;���
            GameObject obj = Instantiate(ProjectilePrefab);
            obj.transform.position = Player.Instance.transform.position;
            CurrentStatus.SpawnTime = BaseStatus.SpawnTime;
        }
        else
        {
            CurrentStatus.SpawnTime -= Time.deltaTime;
        }
    }

}
