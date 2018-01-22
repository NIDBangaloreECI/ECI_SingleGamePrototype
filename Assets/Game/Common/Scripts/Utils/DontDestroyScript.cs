using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

namespace com.nidb.utils
{
	public class DontDestroyScript : MonoBehaviour 
	{
		public void Start()
		{
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}