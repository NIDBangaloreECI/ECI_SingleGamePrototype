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
		[SerializeField]
		private float _collectableStartDisance = 0.5f;
		[SerializeField]
		private float _collectableGap = 0.5f;


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

		private List<GameObject> mSpawnedCollectables = new List<GameObject>();
		public void SetupCollectables(GameObject[] collectables)
		{
			for(int i = mSpawnedCollectables.Count - 1; i >= 0; --i)
			{
				GameObject.DestroyImmediate(mSpawnedCollectables[i]);
				mSpawnedCollectables.RemoveAt(i);
			}
			float dist = -5 + _collectableStartDisance;
			while(dist < 10)
			{
				GameObject c = GameObject.Instantiate(collectables[0], _lanes[1].pLaneTransform) as GameObject;
				Transform t = c.transform;
				t.localScale = new Vector3(1, 1, 0.1f);
				t.localPosition = new Vector3(0, 2, dist);
				dist += _collectableGap;
			}
		}
	}
}