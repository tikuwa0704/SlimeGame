using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObjectManager : MonoBehaviour
{
	static List<GameObject> dontDestroyObjects = new List<GameObject>();

	static public void DontDestroyOnLoad(GameObject obj)
	{
		Object.DontDestroyOnLoad(obj);
		dontDestroyObjects.Add(obj);
	}

	static public void DestoryAll()
	{
		foreach (var obj in dontDestroyObjects)
		{
			GameObject.Destroy(obj);
		}
		dontDestroyObjects.Clear();
	}
}
