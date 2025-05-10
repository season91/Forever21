using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystemManager : MonoBehaviour
{
    [SerializeField] HandlerManager handlerManager;
    [SerializeField] PropertyManager propertyManager;

    public static AttackSystemManager instance { get; private set; }

    private void Reset()
    {
        handlerManager = GetComponent<HandlerManager>();
        propertyManager = GetComponent<PropertyManager>();
        if(handlerManager == null)
        {
            handlerManager = gameObject.AddComponent<HandlerManager>();
        }
        if(propertyManager == null)
        {
            propertyManager = gameObject.AddComponent<PropertyManager>();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        handlerManager.Init();
        propertyManager.Init();
    }

    public ProjectileProperty GetProperty(string _str)
    {
        return propertyManager.GetProperty(_str);
    }

    public BaseAttackHandler GetHandler(AttackHandlerEnum _enum)
    {
        return handlerManager.GetAttackHandle(_enum);
    }



}
