using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Fungus.EditorUtils;

namespace com.nidb.utils
{
	[CustomEditor (typeof(MenuWithSay))]
	public class MenuWithSayEditor : MenuEditor 
	{

		protected SerializedProperty mSayTextProp;

		protected override void OnEnable()
		{
			if (NullTargetCheck()) // Check for an orphaned editor instance
				return;
			
			base.OnEnable();
			mSayTextProp = serializedObject.FindProperty("_sayText");
		}
		
		public override void DrawCommandGUI() 
		{
			base.DrawCommandGUI();
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PropertyField(mSayTextProp);
			EditorGUILayout.EndHorizontal();
			serializedObject.ApplyModifiedProperties();
		}
	}
}