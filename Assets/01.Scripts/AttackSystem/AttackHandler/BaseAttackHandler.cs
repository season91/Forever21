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

    public static Dictionary<AttackHandlerEnum, BaseAttackHandler> AllAttackHandles 
        = new Dictionary<AttackHandlerEnum, BaseAttackHandler>();

    public ProjectileStatus BaseStatus = new ProjectileStatus();

    public ProjectileStatus CurrentStatus = new ProjectileStatus();

    public Dictionary<PropertyEnum, List<ProjectileProperty>> Functions;

    public void AddProperty(ProjectileProperty _property) 
    {
        if (_property == null) return;

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
        //충돌 시 작동될 함수
    }

    public void HandlerUpdate()
    {
        foreach(ProjectileProperty property in Functions[PropertyEnum.Handler])
        {
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
            // object pool의 Get으로 가져와야함
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
