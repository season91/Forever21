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
        AttackDictionary.Add(AttackHandlerEnum.Arrow, gameObject.AddComponent<ArrowAttackHandler>());
    }


    //���� �����ڸ� ���ʿ� �Ⱦ���
    //initialize �� ����մϴ�.
    //�̰Ÿ� ������->�������ڰ� �ڵ����� ȣ���ϰ� �մϴ�.
    //rootcomponent�� �÷��̾� -> attacksystem�� ��� ������ owner��, ��� ������ �ʱ�ȭ
    //player -> attacksystem -> handler   <<<<


    bool IsInit = false;
    public void Init()
    {
        if (IsInit == true) return;
        IsInit = true;
        foreach (KeyValuePair<AttackHandlerEnum, BaseAttackHandler> Pair in AttackDictionary)
        {
            Pair.Value.Init();
        }
    }


    public void AddProperty(AttackHandlerEnum _AttackHandlerEnum, ProjectileProperty _Property)
    {
        AttackDictionary[_AttackHandlerEnum].AddProperty(_Property);
    }

    public void Attack()
    {
#if UNITY_EDITOR
        if (IsInit == false)
        {
            Debug.Log("PlayerAttackSystem Initialize is not work");
        }
#endif

        foreach (KeyValuePair<AttackHandlerEnum, BaseAttackHandler> Pair in AttackDictionary)
        {
            Pair.Value.Attack();
        }
    }
}
