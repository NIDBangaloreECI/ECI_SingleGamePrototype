using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.nidb.games.endlessrunnergame
{
	public class TrackSegment : MonoBehaviour 
	{
		[System.Serializable]
		public class LaneInfo
		{
			[SerializeField]
			private Transform _laneObj;

			public Transform pLaneTransform { get { return _laneObj; } }
		}

		[SerializeField]
		private LaneInfo[] _lanes;

		private const string PLAYER_TAG = "Player";

		public int pNumLanes { get { return _lanes.Length; } }
		
		public void OnTriggerEnter(Collider coll)
		{
			if(coll.tag == PLAYER_TAG)
			{
				EndlessRunnerPlayerController pCtrl = coll.GetComponent<EndlessRunnerPlayerController>();
				pCtrl.SetTrackSegment(this);
			}
		}

		public LaneInfo GetLaneInfo(int laneIdx)
		{
			if(laneIdx >= 0 && laneIdx < _lanes.Length)
				return _lanes[laneIdx];
			return null;
		}
	}
}