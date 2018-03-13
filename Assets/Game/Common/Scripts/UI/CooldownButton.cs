using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.nidb.ecigame.ui
{
	[RequireComponent(typeof(Button))]
	public class CooldownButton : MonoBehaviour 
	{

		[SerializeField]
		private float _cooldownTime = 1;
		[Tooltip("Set to an image object with Type Filled")]
		[SerializeField]
		private Image _cooldownMask;
		[SerializeField]
		private bool _cooldownOnStart = false;

		private Button _button;

		// Use this for initialization
		protected void Start () 
		{
			_button = GetComponent<Button>();
			_button.onClick.AddListener(() => StartCooldown());
			if(_cooldownOnStart)
				StartCooldown();
		}
		
		protected void StartCooldown()
		{
			StartCoroutine(CooldownTick());
		}

		protected IEnumerator CooldownTick()
		{
			_cooldownMask.enabled = true;
			_button.interactable = false;
			float startTime = Time.realtimeSinceStartup;
			while((Time.realtimeSinceStartup - startTime) < _cooldownTime)
			{
				_cooldownMask.fillAmount = (1.0f - (Time.realtimeSinceStartup - startTime) / _cooldownTime);
				yield return new WaitForEndOfFrame();
			}
			_button.interactable = true;
			_cooldownMask.enabled = false;
		}
	}
}