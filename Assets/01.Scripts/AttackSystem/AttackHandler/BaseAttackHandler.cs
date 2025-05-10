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

    //활, 활에 들어갈 특성들 list 
    public Dictionary<PropertyEnum, List<ProjectileProperty>> Functions = new Dictionary<PropertyEnum, List<ProjectileProperty>>();

    public void AddProperty(ProjectileProperty _property) 
    {
        if (_property == null) return;

        if (!Functions.ContainsKey(_property.EnumType))
        {
            Functions[_property.EnumType] = new List<ProjectileProperty>();  // 적절한 리스트 타입으로 초기화
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
        //충돌 시 작동될 함수
    }

    public void HandlerUpdate()  // 공격력 이나 데미지 등이 증가하는 그거라했쬬?
    {
        foreach(ProjectileProperty property in Functions[PropertyEnum.Handler])
        {
            //지금 스텟이 업그레이드 될건데, 일단 초기값으로 돌린 후 업그레이드를 합니다.
            //공격력이 10인데  + 5
            //11로 올라야하는데 base가 5였어요
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
