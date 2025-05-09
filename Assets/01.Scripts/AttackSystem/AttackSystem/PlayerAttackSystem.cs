using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    List<BaseAttackHandler> attackList;

    private void Awake()
    {
        //임시로 넣은 것
        attackList = new List<BaseAttackHandler>();
        attackList.Add(gameObject.AddComponent<ArrowAttackHandler>());
    }

    bool IsInit = false;
    public void Init()
    {
        if (IsInit == true) return;
        IsInit = true;
        foreach (BaseAttackHandler attack in attackList)
        {
            attack.Init();
        }
    }

    public void Attack()
    {
#if UNITY_EDITOR
        if (IsInit == false)
        {
            Debug.Log("PlayerAttackSystem Initialize is not work");
        }
#endif

        foreach (BaseAttackHandler attack in attackList)
        {
            attack.Attack();
        }
    }
}
