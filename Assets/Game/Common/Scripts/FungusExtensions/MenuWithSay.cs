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

		[Tooltip("Notes about the option text for other authors, localization, etc.")]
		[SerializeField] 
		protected string _sayText = "";

		protected MenuDialog mPreviousMenuDialog;

		public override void OnEnter()
		{
			mPreviousMenuDialog = MenuDialog.ActiveMenuDialog;
			base.OnEnter();
			var menuDialog = MenuDialog.GetMenuDialog();
			MenuDialogWithSay menuDlg =  menuDialog as MenuDialogWithSay;
			Debug.Assert(menuDlg != null);
			menuDlg.SetSayText(_sayText);

		}

	}
}