using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

namespace com.nidb.utils
{
	[CommandInfo("Narrative", 
             "Say With Response", 
             "Writes text in a dialog box.")]
	public class SayWithResponse : Say 
	{
		[Tooltip("Set the response text for the continue button")]
		[SerializeField]
		protected string _responseText = "Ok";

		public override void OnEnter()
		{
			base.OnEnter();
			var sayDialog = SayDialog.GetSayDialog();
			SayDialogWithResponse sayDlg =  sayDialog as SayDialogWithResponse;
			Debug.Assert(sayDlg != null);
			sayDlg.SetResponse(_responseText);
		}
	}
}