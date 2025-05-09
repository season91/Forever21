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

    // [�߰��ϼ���] ===========================================================
    public enum PoolObjType 
    {
        Monster,
        Projectile,
        Item
    }
    // =======================================================================

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
    }

    private void Start()
    {
        InitPrefabNames();
        InitGroupDictionary();
        InitPoolDictionary();
    }

    #region Init
    // Prefab �̸� ����
    // ����: Resource Manager�� key������ Prefab�� �̸��� �־���� ��.
    private void InitPrefabNames()
    {
        _prefabNameDictionary = new Dictionary<PoolObjType, string[]>
        {
            // [�߰��ϼ���] ===========================================================
            { PoolObjType.Monster, new string[] { "Monster" } },
            { PoolObjType.Projectile, new string[] { "PlayerNormalAttack" } },
            { PoolObjType.Item, new string[] { "ExpItem", "TempItem" } }
            // =======================================================================
        };
    }

    // Hierachy�� Create�Ǵ� Object���� �θ� ������Ʈ ���� or ���� �� ����
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

    // Pool Object Type ���� �ʿ��� PoolData ����/����
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

    // Resource Manager���� Pool Object���� �̸��� �־� ��������
    private GameObject[] InitPrefabs(string[] names)
    {
        GameObject[] gameObjects = new GameObject[names.Length];

        for (int i = 0; i < names.Length; i++)
        {
            gameObjects[i] = ResourceManager.Instance.GetResource<GameObject>(names[i]);
        }

        return gameObjects;
    }

    // Prefab�� ������ ���� Pool List ����
    // ��) Item[0] == EXP,  Item[1] == Temp
    private List<GameObject>[] InitPools(int length)
    {
        List<GameObject>[] pools = new List<GameObject>[length];
        for (int i = 0; i < length; i++)
        {
            pools[i] = new List<GameObject>();
        }
        return pools;
    }

    #endregion


    /// <summary>
    /// ������ �ε����� �ش��ϴ� Object�� Ǯ���� �����ɴϴ�.
    /// ��Ȱ��ȭ�� Object�� ������ ���� �����Ͽ� ��ȯ�մϴ�.
    /// [ Item = 0: Exp / 1: Temp ]
    /// </summary>
    /// <param name="type">�����Ϸ��� Object�� Ÿ�� enum PoolObjType</param>
    /// <param name="index">Object ���� �ε���</param>
    /// <returns>Ȱ��ȭ�� �ش� GameObject</returns>
    public GameObject Get(PoolObjType type, int index)
    {
        if (!_poolDictionary.ContainsKey(type))
        {
            Debug.LogError($"{type}�� Key�� ������Ʈ Ǯ ��ųʸ��� �߰��ؾ� ��!");
            return null;
        }

        PoolData data = _poolDictionary[type];

        if (index < 0 || index >= data.prefabs.Length)
        {
            Debug.LogError($"{type} ������ �ε��� {index}�� ����");
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
