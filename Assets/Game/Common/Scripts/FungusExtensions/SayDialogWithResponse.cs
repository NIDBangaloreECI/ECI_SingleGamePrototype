using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

namespace com.nidb.utils
{
	public class SayDialogWithResponse : SayDialog 
	{
		public void SetResponse(string responseText)
		{
			continueButton.GetComponentInChildren<Text>().text = responseText;
		}
	}
}