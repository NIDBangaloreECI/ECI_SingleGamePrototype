using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.nidb.games.endlessrunnergame
{

	public class TrackCurveController : MonoBehaviour 
	{
		[Range(-0.01f, 0.01f)]
		public float curveStrength = 0.01f;
		
		int m_CurveStrengthID;

		// Use this for initialization
		void Start () 
		{
			m_CurveStrengthID = Shader.PropertyToID("_CurveStrength");
		}
		
		// Update is called once per frame
		void Update () 
		{
			Shader.SetGlobalFloat(m_CurveStrengthID, curveStrength);
		}
	}
}