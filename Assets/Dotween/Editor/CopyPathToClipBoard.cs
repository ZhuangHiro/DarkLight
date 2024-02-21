using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 
/// 只需要将该脚本拖拽到Unity工程的Assets目录下即可。
/// 
/// </summary>
public class CopyPathToClipBoard
{
    /// <summary>
    /// 将信息复制到剪切板当中
    /// </summary>
    public static void Copy(string format, params object[] args)
    {
        string result = string.Format(format, args);
        TextEditor editor = new TextEditor();
        editor.content = new GUIContent(result);
        editor.OnFocus();
        editor.Copy();
    }

    [MenuItem("Tools/获取物体路径")]
    private static void CopyGameObjectPath()
    {
        UnityEngine.Object obj = Selection.activeObject;
        if (obj == null)
        {
            Debug.LogError("You must select Obj first!");
            return;
        }
        string result = AssetDatabase.GetAssetPath(obj);
        if (string.IsNullOrEmpty(result))//如果不是资源则在场景中查找
        {
            Transform selectChild = Selection.activeTransform;
            if (selectChild != null)
            {
                result = selectChild.name;

                // 下面这句是获取选中物体在监视面版中全部的路径
                // while (selectChild.parent.parent != null)

                // 下面这句是获取选中物体在监视面版中除了根物体的路径
                while (selectChild.parent.parent != null)
                {
                    selectChild = selectChild.parent;
                    result = string.Format("{0}/{1}", selectChild.name, result);
                }
            }
        }
        CopyPathToClipBoard.Copy(result);
        Debug.Log(string.Format("{0}的子路径已复制到剪切板。", obj.name));
    }

}