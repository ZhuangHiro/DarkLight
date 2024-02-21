using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using MadLevelManager;
using UnityEngine;

public class ResourceLoader
{
    private static ResourceLoader instance = null;

    private ResourceLoader()
    {
    }
    public static ResourceLoader GetInstance()
    {
        if (instance == null)
        {
            instance = new ResourceLoader();
        }
        return instance;
    }

    // ui
    private string prefab_path = "Prefabs/Game/";
    public Dictionary<string, GameObject> PrefbsDictionary = new Dictionary<string, GameObject>();

    // ttq ui
    private string ttq_path = "Imgs/main/ttq_tp";
    public Dictionary<string, Sprite> ttq_dic = new Dictionary<string, Sprite>();

    private Sprite[] objets;

    public Sprite[] LoadTTQSprites()
    {
        if (ttq_dic.Count != 0) return objets;
         objets = Resources.LoadAll<Sprite>(ttq_path);

        for (int i = 0; i < objets.Length; i++)
        {
            string temp = objets[i].name;
            //Debug.Log("temp:" + temp);
            ttq_dic.Add(temp, objets[i]);
        }

        return objets;
    }

    public void LoadPrefbs()
    {
        if (PrefbsDictionary.Count != 0) return;
        GameObject[] objets = Resources.LoadAll<GameObject>(prefab_path);

        for (int i = 0; i < objets.Length; i++)
        {
            string temp = objets[i].name;
            Debug.Log("temp:" + temp);
            PrefbsDictionary.Add(temp, objets[i]);
        }
    }

    public GameObject GetPrefab(string name)
    {
        if (PrefbsDictionary.Count == 0)
        {
            Debug.LogError("预制体字典为空");
        }
        else
        {
            GameObject go;
            PrefbsDictionary.TryGetValue(name, out go);
            return go;
        }
        return null;
    }

    public void UnLoadResources()
    {
        PrefbsDictionary.Clear();
        ttq_dic.Clear();
    }
}
