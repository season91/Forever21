using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PropertyString
{
    public static string AddCounter = "COUNTERPROPERTY";
}

public class PropertyManager : MonoBehaviour
{
    public static Dictionary<string, ProjectileProperty> AllPropertys;

    bool IsInit = false;
    public void Init()
    {
        if (IsInit == true) return;

        IsInit = true;
        AllPropertys[PropertyString.AddCounter] = new CounterProperty();


        foreach (KeyValuePair<string, ProjectileProperty> kvp in AllPropertys)
        {
            kvp.Value.Init();
        }
    }


    public ProjectileProperty GetProperty(string _str)
    {
        _str = _str.ToUpper();

        if (AllPropertys.ContainsKey(_str) == true)
        {
            return AllPropertys[_str];
        }
        return null;
    }

}
