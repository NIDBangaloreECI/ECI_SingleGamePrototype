using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace com.nidb.utils
{
	public class FungusTools 
	{
		[MenuItem("NIDB/Fungus Tools/Add Say With Response Dialog")]
		public static void SpawnSayWithResponseDialog()
		{
			GameObject go = SpawnPrefabInScene("Prefabs/PfSayDialogWithResponseTemplate");
			go.transform.position = Vector3.zero;
		}

		[MenuItem("NIDB/Fungus Tools/Add Menu with Say Dialog")]
		public static void SpawnMenuWithSayDialog()
		{
			GameObject go = SpawnPrefabInScene("Prefabs/PfMenuWithSayTemplate");
			go.transform.position = Vector3.zero;
		}
		
		public static GameObject SpawnPrefabInScene(string prefabName)
		{
			GameObject prefab = Resources.Load<GameObject>(prefabName);
			if (prefab == null)
			{
				return null;
			}
			
			GameObject go = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
			PrefabUtility.DisconnectPrefabInstance(go);
			
			SceneView view = SceneView.lastActiveSceneView;
			if (view != null)
			{
				Camera sceneCam = view.camera;
				Vector3 pos = sceneCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f));
				pos.z = 0f;
				go.transform.position = pos;
			}
			
			Selection.activeGameObject = go;
			
			Undo.RegisterCreatedObjectUndo(go, "Create Object");
			
			return go;
		}
	}
}