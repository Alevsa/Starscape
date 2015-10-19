using UnityEngine;
using System.Collections;

public class PlayerLoader : MonoBehaviour 
{
	// This is going to handle important information I guess so stuff can be loaded. 
	// Main thing it exists for right now is to enable and disable the player depending on the scene,
	// By not destroying hte player we maintain his position in the overworld. By having a loader screen 
	// no duplicate players will be generated as the loader is only called on initialisation. To save 
	// we just need to figure out how to save the loader scene.
	
	private GameObject overworldController;
	private GameObject m_OverworldPlayer;
	private string m_Scene = "Overworld";
	
	void Start()
	{
		DontDestroyOnLoad(gameObject);
		m_OverworldPlayer = GameObject.FindGameObjectWithTag("Player");
		DontDestroyOnLoad(m_OverworldPlayer);
		Application.LoadLevel(m_Scene);
	}
	
	void OnLevelWasLoaded()
	{		
		RememberScene();
		SetPlayerActivity();
		if (Application.loadedLevelName != "Overworld")
		{
			// ???
		}
	}
	
	private void RememberScene()
	{
		if (m_Scene != "Loader")
		{
			m_Scene = Application.loadedLevelName;
		}
	}
	
	
	
	#region sets the player prefab to active or inactive depending on the scene
	private void SetPlayerActivity()
	{
		if (Application.loadedLevelName == "Overworld")
		{
			m_OverworldPlayer.SetActive(true);
		}
		else 
		{
			m_OverworldPlayer.SetActive(false);
		}
	}
	#endregion
}
