using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.nidb.games.endlessrunnergame
{
	public abstract class EndlessPlayerCollisionHandler : MonoBehaviour 
	{
		private const string PLAYER_TAG = "Player";
		
		public void OnTriggerEnter(Collider coll)
		{
			if(coll.tag == PLAYER_TAG)
			{
				EndlessRunnerPlayerController pCtrl = coll.GetComponent<EndlessRunnerPlayerController>();
				OnPlayerCollided(pCtrl);
			}
		}

		protected abstract void OnPlayerCollided(EndlessRunnerPlayerController player);
		
	}
}