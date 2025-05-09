using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackHandlerEnum
{
    Arrow = 0,
    Dager = 1,
}

public class BaseAttack : MonoBehaviour
{
    [SerializeField] protected GameObject ProjectilePrefab;

    public static Dictionary<AttackHandlerEnum, BaseAttack> AllAttackHandles;

    public ProjectileStatus BaseStatus;

    public ProjectileStatus CurrentStatus;


    [HideInInspector] public Vector2 Position;
    [HideInInspector] public Vector2 Direction;

    public Dictionary<PropertyEnum, List<ProjectileProperty>> Functions;

    public void AddProperty(ProjectileProperty _property) 
    {
        if (_property == null) return;
        Functions[_property.PropertyType].Add(_property);
    }

    public List<ProjectileProperty> SpawnFunctions;
    public List<ProjectileProperty> PassiveFunctions;
    public List<ProjectileProperty> CollisionFunctions;

    public void PassiveUpdate()
    {

    }

    public void CollisionUpdate()
    {
        //충돌 시 작동될 함수
    }

    public void SpawnUpdate()
    {

    }

    public virtual void AllReset()
    {

    }


    public virtual void Attack()
    {
        if(CurrentStatus.SpawnTime < 0f)
        {

            // object pool의 Get으로 가져와야함
            //GameObject obj = Instantiate(ProjectilePrefab);
            //obj.transform.position = Position;
            //float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
            //obj.transform.rotation = Quaternion.Euler(0, 0, angle);
            CurrentStatus.SpawnTime = BaseStatus.SpawnTime;
        }
        else
        {
            CurrentStatus.SpawnTime -= Time.deltaTime;
        }
    }

}
