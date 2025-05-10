using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 단검, 활, 도끼, 망치  enum (key)
/// 진짜 class (value)
/// 
/// 내가 단검능력을 올릴거다  그래서 enum 레벨업했을 때 특정 무기의 스텟만 올라가야하니 enum으로 관리
/// 
/// 
/// </summary>

public class PlayerAttackSystem : MonoBehaviour
{
    //무기타입, 무기 핸들러
    Dictionary<AttackHandlerEnum, BaseAttackHandler> AttackDictionary;

    private void Awake()
    {
        AttackDictionary = new Dictionary<AttackHandlerEnum, BaseAttackHandler>();

        //arrow attack을 만약 다른 친구들이 접근해야한다고 쳤을 때
        //get component로 접근하면 곤란하겠죠? 
        //그래서 추가한 후 자료구조까지 해줬습니다.
        
    }

    private void Start()
    {
        AttackDictionary.Add(AttackHandlerEnum.Arrow, AttackSystemManager.instance.GetHandler(AttackHandlerEnum.Arrow));
    }


    //저는 생성자를 애초에 안쓰고
    //initialize 를 사용합니다.
    //이거를 소유자->소유권자가 자동으로 호출하게 합니다.
    //rootcomponent가 플레이어 -> attacksystem이 모든 공격의 owner고, 모든 공격을 초기화
    //player -> attacksystem -> handler   <<<<




    public void AddProperty(AttackHandlerEnum _AttackHandlerEnum, ProjectileProperty _Property)
    {
        AttackDictionary[_AttackHandlerEnum].AddProperty(_Property);
    }

    public void Attack()
    {
#if UNITY_EDITOR

#endif

        foreach (KeyValuePair<AttackHandlerEnum, BaseAttackHandler> Pair in AttackDictionary)
        {
            Pair.Value.Attack();
        }
    }

    // 공격 수단 추가
    public void AddAttack(AttackHandlerEnum type)
    {
        AttackDictionary.Add(type, AttackSystemManager.instance.GetHandler(type));
    }
}
