using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Fungus;
using Fungus.EditorUtils;

namespace com.nidb.utils
{
	[CustomEditor (typeof(MenuWithSay))]
	public class MenuWithSayEditor : MenuEditor 
	{

		protected SerializedProperty mCharacterProp;
		protected SerializedProperty mPortraitProp;
		protected SerializedProperty mSayTextProp;

		protected override void OnEnable()
		{
			if (NullTargetCheck()) // Check for an orphaned editor instance
				return;
			
			base.OnEnable();
			mCharacterProp = serializedObject.FindProperty("_character");
			mPortraitProp = serializedObject.FindProperty("_portrait");
			mSayTextProp = serializedObject.FindProperty("_sayText");
		}
		
		public override void DrawCommandGUI() 
		{
			base.DrawCommandGUI();
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PropertyField(mSayTextProp);
			EditorGUILayout.EndHorizontal();
			ShowCharacterProp();
			serializedObject.ApplyModifiedProperties();
		}

		private void ShowCharacterProp()
		{
			bool showPortraits = false;
			CommandEditor.ObjectField<Character>(mCharacterProp,
			                                     new GUIContent("Character", "Character that is speaking"),
			                                     new GUIContent("<None>"),
			                                     Character.ActiveCharacters);
			
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel(" ");
			mCharacterProp.objectReferenceValue = (Character) EditorGUILayout.ObjectField(mCharacterProp.objectReferenceValue, typeof(Character), true);
			EditorGUILayout.EndHorizontal();
			
			MenuWithSay t = target as MenuWithSay;
			
			// Only show portrait selection if...
			if (t.pCharacter != null &&              // Character is selected
			    t.pCharacter.Portraits != null &&    // Character has a portraits field
			    t.pCharacter.Portraits.Count > 0 )   // Selected Character has at least 1 portrait
			{
				showPortraits = true;    
			}
			
			if (showPortraits) 
			{
				CommandEditor.ObjectField<Sprite>(mPortraitProp, 
				                                  new GUIContent("Portrait", "Portrait representing speaking character"), 
				                                  new GUIContent("<None>"),
				                                  t.pCharacter.Portraits);
			}
			else
			{
				t.pPortrait = null;
			}
		}
	}
}