using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.nidb.games.endlessrunnergame
{
	public class TrackManager : MonoBehaviour 
	{
		[Header("Track Info")]
		[SerializeField]
		private Transform _trackSegmentsRoot;
		[SerializeField]
		private int _numTrackSegmentsToShow = 3;
		[Header("Move Speeds")]
		[SerializeField]
		private float _minSpeed = 2;
		[SerializeField]
		private float _maxSpeed = 6;
		[SerializeField]
		private GameObject[] _collectables;

		private List<TrackSegment> mCurrentTrackSegments = new List<TrackSegment>();
		private List<TrackSegment> mUnusedTrackSegments = new List<TrackSegment>();
		private float mCurrentSpeed;

		private float mDistanceTravelled = 0;
		private float mSpeedUpdateDistance = 100;
		private float mNextSpeedUpdateDistance = 100;

		private const int TRACK_SEGMENT_LENGTH = 100;				//< ToDo: Allow configuring this for every track.
		private bool mIsStunned = false;											//< Player is stunned
		private bool mIsPaused = false;												//< Game is paused

		public bool pIsMoving { get { return (!mIsPaused && !mIsStunned); } }

		// Use this for initialization
		void Start () 
		{
			InitGame();
		}

		
		public void Update()
		{
			if(pIsMoving)
				MoveUpdate();
		}

		private void MoveUpdate()
		{
			Vector3 moveDelta = new Vector3(0, 0, -mCurrentSpeed * Time.deltaTime);
			for(int i = 0; i < mCurrentTrackSegments.Count; ++i)
				mCurrentTrackSegments[i].transform.localPosition += moveDelta;
			if(mCurrentTrackSegments[0].transform.localPosition.z <= -50)
				RefreshTrackSegments();
			
			mDistanceTravelled += (mCurrentSpeed * Time.deltaTime);
			if((mCurrentSpeed < _maxSpeed) && (mDistanceTravelled > mNextSpeedUpdateDistance))
			{
				mNextSpeedUpdateDistance += mSpeedUpdateDistance;
				mCurrentSpeed += ((_maxSpeed - _minSpeed) / 10); 
			}
		}

		public void InitGame()
		{
			InitTracks();

			mCurrentSpeed = _minSpeed;
			mDistanceTravelled = 0;
			mNextSpeedUpdateDistance = mSpeedUpdateDistance;
		}

		private void InitTracks()
		{
			TrackSegment[] trackSegments =  _trackSegmentsRoot.GetComponentsInChildren<TrackSegment>();
			foreach(TrackSegment ts in trackSegments)
			{
				ts.gameObject.SetActive(false);
				mUnusedTrackSegments.Add(ts);
			}
			
			for(int i = 0; i < _numTrackSegmentsToShow; ++i)
			{
				SelectNextTrackSegment();
			}
		}

		private TrackSegment SelectNextTrackSegment()
		{
			int rnd = Random.Range(0, mUnusedTrackSegments.Count);
			TrackSegment outSeg = mUnusedTrackSegments[rnd];
			mUnusedTrackSegments.RemoveAt(rnd);
			mCurrentTrackSegments.Add(outSeg);
			outSeg.transform.localPosition = new Vector3(0, 0, (mCurrentTrackSegments.Count - 1) * TRACK_SEGMENT_LENGTH);
			outSeg.gameObject.SetActive(true);
			outSeg.SetupCollectables(_collectables);
			return outSeg;
		}

		private void RefreshTrackSegments()
		{
			TrackSegment removedSeg = mCurrentTrackSegments[0];
			removedSeg.gameObject.SetActive(false);
			mCurrentTrackSegments.RemoveAt(0);
			Vector3 pos = mCurrentTrackSegments[mCurrentTrackSegments.Count - 1].transform.localPosition;
			TrackSegment newSeg  = SelectNextTrackSegment();
			pos.z += TRACK_SEGMENT_LENGTH;
			newSeg.transform.localPosition = pos;
			mUnusedTrackSegments.Add(removedSeg);
		}

	}
}