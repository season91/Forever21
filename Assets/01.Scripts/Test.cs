using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = PoolManager.Instance.Get(PoolManager.PoolObjType.Monster, 0);
        }
    }
}
