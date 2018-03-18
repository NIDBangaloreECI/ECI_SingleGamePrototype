using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace com.nidb.games.hiddenobjectgame
{
	/**
	 * Handles a hidden object in the game scene
	 */
	public class ValidObjectsScript : MonoBehaviour, IPointerClickHandler
	{
		public delegate void ObjectFoundListener();

		[SerializeField]
		private Sprite _menuIcon;
		[SerializeField]
		private string _name;
		[SerializeField]
		[Tooltip("Points awarded when player finds this object")]
		private int _score = 1;


		[SerializeField]
		private Image _blinkImage;
		[SerializeField]
		private float _blinkFrequency = 0.5f;
		[SerializeField]
		private float _blinkDuration = 2;

		private ObjectFoundListener mOnObjectFound = null;

		public Sprite pMenuIconSprite { get { return _menuIcon; } }
		public string pName { get { return (string.IsNullOrEmpty(_name) ? gameObject.name : _name); } }
		public int pScore { get { return _score; } }

		public event ObjectFoundListener pObjectFound
		{
			add { mOnObjectFound += value; }
			remove { mOnObjectFound -= value; }
		}

		// Use this for initialization
		public void Start () 
		{
		}
		
		// Update is called once per frame
		public void Update () 
		{
			
		}

		public void OnEnable()
		{
			_blinkImage.enabled = true;
		}

		public void OnPointerClick(PointerEventData pEvData)
		{
			if (isActiveAndEnabled) 
			{
				if(mOnObjectFound != null)
					mOnObjectFound();
				enabled = false;
				Destroy (this.gameObject);
			}
		}

		public void Highlight()
		{
			Animator anim = GetComponent<Animator>();
			if(anim != null)
				anim.SetTrigger("TriggerScale");
			else
				StartCoroutine (BlinkFunc());
		}

		private IEnumerator BlinkFunc()
		{
			float startTime = Time.realtimeSinceStartup;
			while((Time.realtimeSinceStartup - startTime) < _blinkDuration)
			{
				yield return new WaitForSeconds(_blinkFrequency);
				_blinkImage.enabled = !_blinkImage.enabled;
			}
			_blinkImage.enabled = true;
		}

	}
}