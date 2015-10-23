using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GameObject CreditsPanel;

	public void NewGame()
	{
		Application.LoadLevel("Overworld");
	}
	
	public void Load()
	{
	
	}
	
	public void Options()
	{
	
	}
	
	public void Credits()
	{
		if (!CreditsPanel.activeSelf)
			CreditsPanel.SetActive(true);
		else 
			CreditsPanel.SetActive(false);
	}
	
	// Make it ask if you're sure
	public void Quit()
	{
		Application.Quit();
	}
}
