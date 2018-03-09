using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.nidb.games.endlessrunnergame
{
	public class EndlessObstacle : EndlessPlayerCollisionHandler 
	{

		// Use this for initialization
		void Start () 
		{
			
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}
		
		protected override void OnPlayerCollided(EndlessRunnerPlayerController player)
		{
			Debug.Log ("Crashed");
		}
	}
}