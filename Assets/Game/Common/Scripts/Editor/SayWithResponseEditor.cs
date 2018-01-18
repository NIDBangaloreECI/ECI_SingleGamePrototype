using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Fungus.EditorUtils;


namespace com.nidb.utils
{
	[CustomEditor (typeof(SayWithResponse))]
	public class SayWithResponseEditor : SayEditor 
	{
		protected SerializedProperty mResponseTextProp;

		protected override void OnEnable()
		{
			if (NullTargetCheck()) // Check for an orphaned editor instance
				return;

			base.OnEnable();
			mResponseTextProp = serializedObject.FindProperty("_responseText");
		}

		public override void DrawCommandGUI() 
		{
			base.DrawCommandGUI();
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PropertyField(mResponseTextProp);
			EditorGUILayout.EndHorizontal();
			serializedObject.ApplyModifiedProperties();
		}
	}
}