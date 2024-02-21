using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AssetBundleTool
{

    [MenuItem("Tools/CreatBundles/Android")]
    static void CreatBundle()
    {
        string dir = "AssetBundles";
        if (Directory.Exists(dir) == false)
        {
            Directory.CreateDirectory(dir);
        }
    }

    [MenuItem("Tools/CreatBundles/IOS")]
    static void CreatBundleIOS()
    {
        string dir = "AssetBundles";
        if (Directory.Exists(dir) == false)
        {
            Directory.CreateDirectory(dir);
        }
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.iOS);
    }
}
