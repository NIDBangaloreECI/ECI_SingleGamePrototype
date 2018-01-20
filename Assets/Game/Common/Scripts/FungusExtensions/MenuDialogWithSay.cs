using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

namespace com.nidb.utils
{
	public class MenuDialogWithSay : MenuDialog 
	{
		[Tooltip("The name text UI object")]
		[SerializeField] 
		protected Text _nameText;
		
		[Tooltip("The story text UI object")]
		[SerializeField]
		private Text _sayText;

		[Tooltip("The character UI object")]
		[SerializeField] 
		protected Image _characterImage;

		[Tooltip("Adjust width of story text when Character Image is displayed (to avoid overlapping)")]
		[SerializeField] 
		protected bool fitTextWithImage = true;

		// Most recent speaking character
		protected static Character speakingCharacter;
		protected Sprite mCurrentCharacterImage;
		protected float startStoryTextWidth; 
		protected float startStoryTextInset;
		protected StringSubstituter stringSubstituter = new StringSubstituter();

		public virtual void Start()
		{
			// It's possible that SetCharacterImage() has already been called from the
			// Start method of another component, so check that no image has been set yet.
			// Same for nameText.
			
			if (_nameText != null && _nameText.text == "")
			{
				SetCharacterName("", Color.white);
			}
			if (mCurrentCharacterImage == null)
			{                
				// Character image is hidden by default.
				SetCharacterImage(null);
			}
		}

		public void SetSayText(string sayText)
		{
			_sayText.text = sayText;
		}

		/// <summary>
		/// Sets the active speaking character.
		/// </summary>
		/// <param name="character">The active speaking character.</param>
		public virtual void SetCharacter(Character character)
		{
			if (character == null)
			{
				if (_characterImage != null)
				{
					_characterImage.gameObject.SetActive(false);
				}
				if (_nameText != null)
				{
					_nameText.text = "";
				}
				speakingCharacter = null;
			}
			else
			{
				var prevSpeakingCharacter = speakingCharacter;
				speakingCharacter = character;
				
				// Dim portraits of non-speaking characters
				var activeStages = Stage.ActiveStages;
				for (int i = 0; i < activeStages.Count; i++)
				{
					var stage = activeStages[i];
					if (stage.DimPortraits)
					{
						var charactersOnStage = stage.CharactersOnStage;
						for (int j = 0; j < charactersOnStage.Count; j++)
						{
							var c = charactersOnStage[j];
							if (prevSpeakingCharacter != speakingCharacter)
							{
								if (c != null && !c.Equals(speakingCharacter))
								{
									stage.SetDimmed(c, true);
								}
								else
								{
									stage.SetDimmed(c, false);
								}
							}
						}
					}
				}
				
				string characterName = character.NameText;
				
				if (characterName == "")
				{
					// Use game object name as default
					characterName = character.GetObjectName();
				}
				
				SetCharacterName(characterName, character.NameColor);
			}
		}
		
		/// <summary>
		/// Sets the character image to display on the Say Dialog.
		/// </summary>
		public virtual void SetCharacterImage(Sprite image)
		{
			if (_characterImage == null)
			{
				return;
			}
			
			if (image != null)
			{
				_characterImage.sprite = image;
				_characterImage.gameObject.SetActive(true);
				mCurrentCharacterImage = image;
			}
			else
			{
				_characterImage.gameObject.SetActive(false);
				
				if (startStoryTextWidth != 0)
				{
					_sayText.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 
					                                                      startStoryTextInset, 
					                                                      startStoryTextWidth);
				}
			}
			
			// Adjust story text box to not overlap image rect
			if (fitTextWithImage && 
			    _sayText != null &&
			    _characterImage.gameObject.activeSelf)
			{
				if (Mathf.Approximately(startStoryTextWidth, 0f))
				{
					startStoryTextWidth = _sayText.rectTransform.rect.width;
					startStoryTextInset = _sayText.rectTransform.offsetMin.x; 
				}
				
				// Clamp story text to left or right depending on relative position of the character image
				if (_sayText.rectTransform.position.x < _characterImage.rectTransform.position.x)
				{
					_sayText.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 
					                                                      startStoryTextInset, 
					                                                      startStoryTextWidth - _characterImage.rectTransform.rect.width);
				}
				else
				{
					_sayText.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 
					                                                      startStoryTextInset, 
					                                                      startStoryTextWidth - _characterImage.rectTransform.rect.width);
				}
			}
		}
		
		/// <summary>
		/// Sets the character name to display on the Say Dialog.
		/// Supports variable substitution e.g. John {$surname}
		/// </summary>
		public virtual void SetCharacterName(string name, Color color)
		{
			if (_nameText != null)
			{
				var subbedName = stringSubstituter.SubstituteStrings(name);
				_nameText.text = subbedName;
				_nameText.color = color;
			}
		}
		
	}
}