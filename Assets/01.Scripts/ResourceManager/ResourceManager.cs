using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEngine;

public class ResourceManager
{
    static ResourceManager instance = null;


    //monobehaviour면, 만약에 attacksystem이 먼저 awawke 에서 초기화
    //그때 instantce가 없음
    public static ResourceManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new ResourceManager();
                instance.ResourceSearch();
                return instance;
            }
            return instance;
        }
    }

    Dictionary<string, Object> resources = new Dictionary<string, Object>();
    string ResourcesPath;

    private void ResourceSearch()
    {
        string AssetsFolderPath = Application.dataPath;
        ResourcesPath = Path.Combine(AssetsFolderPath, "Resources");

        bool isfile = File.Exists(ResourcesPath);
        FindAssetsRecursive(ResourcesPath);
    }

    void FindAssetsRecursive(string _path)
    {
        string[] Files = Directory.GetFiles(_path);
        string[] Folders = Directory.GetDirectories(_path);

        foreach(string File in Files)
        {
            string extension = Path.GetExtension(File);
            if(extension == ".meta")
            {
                continue;
            }
            string resourcesPath = File.Replace(ResourcesPath, "");

            string KeyName = Path.GetFileNameWithoutExtension(resourcesPath);
            KeyName = KeyName.ToUpper();

            string FilePath = Path.ChangeExtension(resourcesPath, "");

            int dotIndex = FilePath.LastIndexOf('.');

            FilePath = FilePath.Remove(dotIndex);

            string UpdatePath = FilePath.Replace("\\", "/");

            UpdatePath = UpdatePath.Substring(1);
            Object Obj = Resources.Load(UpdatePath);
            resources[KeyName] = Obj;
        }

        foreach (string path in Folders)
        {
            FindAssetsRecursive(path);
        }
    }

    public T GetResource<T>(string _Key) where T : Object
    {
        _Key = _Key.ToUpper();
        if (!resources.ContainsKey(_Key))
        {
            return null;
        }
        Object obj = resources[_Key];
        T Obj = obj as T;
        return Obj;
    }
}


