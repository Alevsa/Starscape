using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GameObject CreditsPanel = null;
	public GameObject OptionsPanel = null;
	public GameObject NewGamePanel = null;
	public GameObject LoadPanel = null;
	
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
		if (CreditsPanel)
			CloseAllWindows();
		else
			CloseAllWindows(); 
			CreditsPanel.SetActive(true);
	}
	
	public void CloseAllWindows()
	{
		CreditsPanel.SetActive(false);
		if (OptionsPanel)
			OptionsPanel.SetActive(false);
		if (NewGamePanel)
			NewGamePanel.SetActive(false);
		if (LoadPanel)
			LoadPanel.SetActive(false);
	}
	// Make it ask if you're sure
	public void Quit()
	{
		Application.Quit();
	}
}
