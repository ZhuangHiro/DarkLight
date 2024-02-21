//
// /**************************************************************************
//
// DDOLSingleton.cs
//
// Author: xiaohong  <704872627@qq.com>
//
// Unity课程讨论群:  152767675
//
// Date: 15-8-6
//
// Description:Provide  functions  to connect Oracle
//
// Copyright (c) 2015 xiaohong
//
//2015-12-28调整：飘字功能制作editor编辑器功能，需要起始挂到DDOL上，防止运行后再次创建，把_Instance = go.AddComponent<T>();调整为：_Instance = go.GetOrAddComponent<T>();
// **************************************************************************/
using UnityEngine;
using System.Collections;

/// <summary>
/// DDOL singleton.
/// </summary>
public abstract class DDOLSingleton<T> : MonoBehaviour where T : DDOLSingleton<T>
{
	protected static T _Instance = null;

	public static T Instance {
		get {
			if (null == _Instance) {
				GameObject go = GameObject.Find ("DDOL");
				if (null == go) {
					go = new GameObject ("DDOL");
					DontDestroyOnLoad (go);
				}
				_Instance = go.GetOrAddCompoment<T>();
			}
			return _Instance;
		}
	}

	/// <summary>
	/// Raises the application quit event.
	/// </summary>
	private void OnApplicationQuit ()
	{
		_Instance = null;
	}
}
	