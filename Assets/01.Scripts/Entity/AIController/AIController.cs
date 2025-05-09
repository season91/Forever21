using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIController : IInitializeInterface
{
    bool IsInit = false;

    GameObject Target;

    public GameObject MyObject;

    public Vector2 TargetDirection = Vector2.zero;
    public Vector2 MyPos = Vector2.zero;

    public Vector2 Direction = Vector2.zero;
    public void Init()
    {
        if (IsInit == true) return;
        Target = Player.Instance.gameObject;
    }

    public void InitUpdate()
    {
        TargetDirection = Target.transform.position;
        MyPos = MyObject.transform.position;

        Direction = TargetDirection - MyPos;
        Direction = Direction.normalized;
    }

}
