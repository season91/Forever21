using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Dinosaur : Entity
{
    private void Start()
    {
        controller = new AIController();
        status = new EntityStatus();

        InitList.Add(controller);
        InitList.Add(status);

        controller.MyObject = gameObject;

        Init();
    }
}
