using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FairyGUI
{
	/// <summary>
	/// 
	/// </summary>
	public class StageEngine : MonoBehaviour
	{
		public int ObjectsOnStage;
		public int GraphicsOnStage;

		void LateUpdate()
		{
			Stage.inst.InternalUpdate();

			ObjectsOnStage = Stats.ObjectCount;
			GraphicsOnStage = Stats.GraphicsCount;
		}

#if FAIRYGUI_DLL || UNITY_WEBPLAYER || UNITY_WEBGL || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
		void OnGUI()
		{
			Stage.inst.HandleGUIEvents(Event.current);
		}
#endif

		void OnEnable()
		{
			SceneManager.sceneLoaded += OnSceneLoaded;
		}

		void OnDisable()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
		}

		void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			StageCamera.CheckMainCamera();
		}

		void OnApplicationQuit()
		{
			if (Application.isEditor)
				UIPackage.RemoveAllPackages(true);
		}
	}
}