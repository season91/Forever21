using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolData
{
    public GameObject[] prefabs;
    public GameObject group;
    public List<GameObject>[] pools;
}

public class PoolManager : MonoBehaviour
{
    static PoolManager instance = null;

    public static PoolManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    // ===========================================================

    // [추가하세요] ===========================================================
    public enum PoolObjType
    {
        Monster,
        Projectile,
        Item
    }
    private string GetEnumStringToKor(PoolObjType type) =>
    type switch
    {
        PoolObjType.Monster => "Monster",
        PoolObjType.Projectile => "Projectile",
        PoolObjType.Item => "Item",
        _ => "Null"
    };

    private Dictionary<PoolObjType, PoolData> _poolDictionary;
    private Dictionary<PoolObjType, GameObject> _groupDictionary;
    private Dictionary<PoolObjType, string[]> _prefabNameDictionary;

    // ===========================================================

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        InitPrefabNames();
        InitGroupDictionary();
        InitPoolDictionary();
    }

    private void InitPrefabNames()
    {
        _prefabNameDictionary = new Dictionary<PoolObjType, string[]>
        {
            // [추가하세요] ===========================================================
            { PoolObjType.Monster, new string[] { "Monster1", "Monster2" } },
            { PoolObjType.Projectile, new string[] { "Bullet1", "Bullet2" } },
            { PoolObjType.Item, new string[] { "Exp" } }
        };
    }

    private void InitGroupDictionary()
    {
        _groupDictionary = new Dictionary<PoolObjType, GameObject>();

        foreach (PoolObjType type in Enum.GetValues(typeof(PoolObjType)))
        {
            string name = GetEnumStringToKor(type);
            Transform child = transform.Find($"{name}PoolGroup");

            GameObject group;

            if (child != null)
            {
                group = child.gameObject;
            }
            else
            {
                group = new GameObject($"{name}PoolGroup");
                group.transform.SetParent(transform);
            }

            _groupDictionary[type] = group;
        }
    }

    private void InitPoolDictionary()
    {
        _poolDictionary = new Dictionary<PoolObjType, PoolData>();

        foreach (PoolObjType type in Enum.GetValues(typeof(PoolObjType)))
        {
            string[] prefabNames = _prefabNameDictionary[type];

            _poolDictionary[type] = new PoolData
            {
                prefabs = InitPrefabs(prefabNames),
                group = _groupDictionary[type],
                pools = InitPools(prefabNames.Length)
            };
        }
    }

    private GameObject[] InitPrefabs(string[] names)
    {
        GameObject[] gameObjects = new GameObject[names.Length];

        for (int i = 0; i < names.Length; i++)
        {
            gameObjects[i] = ResourceManager.Instance.GetResource<GameObject>(names[i]);
        }

        return gameObjects;
    }

    private List<GameObject>[] InitPools(int length)
    {
        List<GameObject>[] pools = new List<GameObject>[length];
        for (int i = 0; i < length; i++)
        {
            pools[i] = new List<GameObject>();
        }
        return pools;
    }

    /// <summary>
    /// 지정한 인덱스에 해당하는 Object를 풀에서 가져옵니다.
    /// 비활성화된 Object가 없으면 새로 생성하여 반환합니다.
    /// </summary>
    /// <param name="type"> 생성하려는 Object의 타입 enum PoolObjType </param>
    /// <param name="index"> Object 종류 인덱스 </param>
    /// <returns> 활성화된 해당 GameObject </returns>
    public GameObject Get(PoolObjType type, int index)
    {
        if (!_poolDictionary.ContainsKey(type))
        {
            Debug.LogError($"{type}의 Key를 오브젝트 풀 딕셔너리에 추가해야 됨!");
            return null;
        }

        PoolData data = _poolDictionary[type];

        if (index < 0 || index >= data.prefabs.Length)
        {
            Debug.LogError($"{type} 종류에 인덱스 {index}가 없음");
            return null;
        }

        List<GameObject> poolList = data.pools[index];

        foreach (var obj in poolList)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(data.prefabs[index], data.group.transform);
        poolList.Add(newObj);
        return newObj;
    }
}
