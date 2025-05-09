using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour
{
    List<BaseAttack> attackList;

    public void Attack()
    {
        foreach (BaseAttack attack in attackList)
        {
            attack.Attack();
        }
    }
}
