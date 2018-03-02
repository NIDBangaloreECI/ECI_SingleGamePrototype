using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.nidb.games.endlessrunnergame
{
	public class EndlessRunnerPlayerController: MonoBehaviour 
	{

		private int mCurrentLane = -1;

		public bool pCanMoveLeft { get { return (mCurrentLane > 0); } }
		public bool pCanMoveRight { get { return (mCurrentLane < (mCurrTrackSegment.pNumLanes - 1)); } }

		private TrackSegment mCurrTrackSegment;
		
		// Update is called once per frame
		void Update () 
		{
			if(Input.GetKeyDown(KeyCode.RightArrow))
				MoveRight();
			if(Input.GetKeyDown(KeyCode.LeftArrow))
				MoveLeft();
			if(Input.GetKeyDown(KeyCode.UpArrow))
				Jump();
		}

		public void SetTrackSegment(TrackSegment newSeg)
		{
			mCurrTrackSegment = newSeg;
			if(mCurrentLane < 0)
				mCurrentLane = mCurrTrackSegment.pNumLanes / 2;
			MoveToLane(mCurrentLane);
		}

		public void MoveRight()
		{
			if(pCanMoveRight)
			{
				mCurrentLane++;
				MoveToLane(mCurrentLane);
			}
		}

		public void MoveLeft()
		{
			if(pCanMoveLeft)
			{
				mCurrentLane--;
				MoveToLane(mCurrentLane);
			}
		}

		public void Jump()
		{
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
		}

		private void MoveToLane(int laneIdx)
		{
			TrackSegment.LaneInfo laneInfo = mCurrTrackSegment.GetLaneInfo(mCurrentLane);
			Vector3 pos = transform.localPosition;
			pos.x = laneInfo.pLaneTransform.localPosition.x;
			transform.localPosition = pos;
		}
		
	}
}