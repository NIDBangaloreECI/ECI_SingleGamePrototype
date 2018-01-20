using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

namespace com.nidb.utils
{
	[CommandInfo("Narrative", 
	             "Menu WithSay", 
	             "Adds text in a menu dialog box. Resets the Menu dialog after use.")]
	public class MenuWithSay : Menu 
	{

		[Tooltip("Character that is speaking")]
		[SerializeField] 
		protected Character _character;

		[Tooltip("Portrait that represents speaking character")]
		[SerializeField] 
		protected Sprite _portrait;

		[Tooltip("Notes about the option text for other authors, localization, etc.")]
		[SerializeField] 
		protected string _sayText = "";

		protected MenuDialog mPreviousMenuDialog;

		/// <summary>
		/// Character that is speaking.
		/// </summary>
		public Character pCharacter { get { return _character; } }
		/// <summary>
		/// Portrait that represents speaking character.
		/// </summary>
		public virtual Sprite pPortrait { get { return _portrait; } set { _portrait = value; } }

		public override void OnEnter()
		{
			mPreviousMenuDialog = MenuDialog.ActiveMenuDialog;
			base.OnEnter();
			var menuDialog = MenuDialog.GetMenuDialog();
			MenuDialogWithSay menuDlg =  menuDialog as MenuDialogWithSay;
			Debug.Assert(menuDlg != null);
			menuDlg.SetSayText(_sayText);
			menuDlg.SetCharacter(_character);
			menuDlg.SetCharacterImage(_portrait);
		}

	}
}