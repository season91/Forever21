using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    List<BaseAttackHandler> attackList;

    private void Awake()
    {
        attackList = new List<BaseAttackHandler>();
        attackList.Add(new ArrowAttackHandler());
    }

    public void Init()
    {
        foreach (BaseAttackHandler attack in attackList)
        {
            attack.Init();
        }
    }

    public void Attack()
    {
        foreach (BaseAttackHandler attack in attackList)
        {
            attack.Attack();
        }
    }
}
