using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace com.nidb.data
{
	[System.Serializable]
	public class ECIGameEpisodeInfo
	{
		[Tooltip("The name of the episode")]
		[SerializeField]
		private string _name;

		[Tooltip("The starting scene for the episode")]
		[SerializeField]
		private string _sceneName;
		[Tooltip("Icon used to denote the Episode")]
		[SerializeField]
		private Sprite _icon;
		[Tooltip("Episode Description")]
		[SerializeField]
		private string _description;

		public string pName { get { return _name; } }
		public string pSceneName { get { return _sceneName; } }
		public Sprite pIcon { get { return _icon; } }
		public string pDescription { get { return _description; } }
	}

	public class ECIGameEpisodes : ScriptableObject 
	{
		[Tooltip("Lists all active episodes in the game")]
		[SerializeField]
		private ECIGameEpisodeInfo[] _episodes;

		public int pEpisodeCount { get { return _episodes.Length; } }

		[MenuItem("NIDB/ECI Game Tools/Data/Create Game Episodes List")]
		public static void CreateAsset()
		{
			ECIGameEpisodes obj = ScriptableObject.CreateInstance<ECIGameEpisodes>();
			string path = AssetDatabase.GetAssetPath(Selection.activeObject);
			if(string.IsNullOrEmpty(path))
				path = "Assets";
			string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + typeof(ECIGameEpisodes).ToString() + ".asset");
			AssetDatabase.CreateAsset(obj, assetPathAndName);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}

		public void LoadEpisode(int episodeIndex)
		{
			if(episodeIndex >= 0 && episodeIndex < _episodes.Length)
				SceneManager.LoadScene(_episodes[episodeIndex].pSceneName);
		}

		public void SetupEpisodeButton(Button episodeButton, int episodeIndex)
		{
			if(episodeIndex >= 0 && episodeIndex < _episodes.Length)
			{
				ECIGameEpisodeInfo epInfo = _episodes[episodeIndex];
				episodeButton.image.sprite = epInfo.pIcon;
				episodeButton.GetComponentInChildren<Text>().text = epInfo.pName;
			}
		}
	}
}