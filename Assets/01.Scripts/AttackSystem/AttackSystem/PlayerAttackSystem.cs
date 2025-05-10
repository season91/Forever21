using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ܰ�, Ȱ, ����, ��ġ  enum (key)
/// ��¥ class (value)
/// 
/// ���� �ܰ˴ɷ��� �ø��Ŵ�  �׷��� enum ���������� �� Ư�� ������ ���ݸ� �ö󰡾��ϴ� enum���� ����
/// 
/// 
/// </summary>

public class PlayerAttackSystem : MonoBehaviour
{
    //����Ÿ��, ���� �ڵ鷯
    Dictionary<AttackHandlerEnum, BaseAttackHandler> AttackDictionary;

    private void Awake()
    {
        AttackDictionary = new Dictionary<AttackHandlerEnum, BaseAttackHandler>();

        //arrow attack�� ���� �ٸ� ģ������ �����ؾ��Ѵٰ� ���� ��
        //get component�� �����ϸ� ����ϰ���? 
        //�׷��� �߰��� �� �ڷᱸ������ ������ϴ�.
        
    }

    private void Start()
    {
        AttackDictionary.Add(AttackHandlerEnum.Arrow, AttackSystemManager.instance.GetHandler(AttackHandlerEnum.Arrow));
    }


    //���� �����ڸ� ���ʿ� �Ⱦ���
    //initialize �� ����մϴ�.
    //�̰Ÿ� ������->�������ڰ� �ڵ����� ȣ���ϰ� �մϴ�.
    //rootcomponent�� �÷��̾� -> attacksystem�� ��� ������ owner��, ��� ������ �ʱ�ȭ
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

    // ���� ���� �߰�
    public void AddAttack(AttackHandlerEnum type)
    {
        AttackDictionary.Add(type, AttackSystemManager.instance.GetHandler(type));
    }
}
