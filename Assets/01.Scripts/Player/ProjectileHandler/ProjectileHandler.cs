using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    List<BaseAttack> attackList;

    private void Awake()
    {
        attackList = new List<BaseAttack>();
        attackList.Add(new ArrowAttackController());
    }

    public void Init()
    {
        foreach (BaseAttack attack in attackList)
        {
            attack.Init();
        }
    }

    public void Attack()
    {
        foreach (BaseAttack attack in attackList)
        {
            attack.Attack();
        }
    }
}
