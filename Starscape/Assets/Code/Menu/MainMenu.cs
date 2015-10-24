using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GameObject CreditsPanel = null;
	public GameObject OptionsPanel = null;
	public GameObject NewGamePanel = null;
	public GameObject LoadPanel = null;
	
	public void TogglePanel(GameObject panel)
	{
		if (panel.activeSelf)
		{
			CloseAllWindows();
		}
		else
		{
			CloseAllWindows(); 
			panel.SetActive(true);
		}
	}
	
	public void CloseAllWindows()
	{
		CreditsPanel.SetActive(false);
		OptionsPanel.SetActive(false);
		NewGamePanel.SetActive(false);
		LoadPanel.SetActive(false);
	}
	// Make it ask if you're sure
	public void Quit()
	{
		Application.Quit();
	}
}
