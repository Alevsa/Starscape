using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{
	public Toggle MouseControlToggle = null;
	public Toggle InvertedYAxis = null;
	public Transform Player = null;
	public GameObject OptionsPanel = null;
	public GameObject MainPanel = null;
	
	void Start()
	{
		if (SaveLoadController.GetYAxisInversion() == -1)
			InvertedYAxis.isOn = true;
		else 
			InvertedYAxis.isOn = false;
		
		if (SaveLoadController.GetMouseControl())
			MouseControlToggle.isOn = true;
		else
			MouseControlToggle.isOn = false;	
	}
	
	public void TogglePauseMenu()
	{
		if (MainPanel.activeSelf)
		{
			MainPanel.SetActive(false);
			OptionsPanel.SetActive(false);
			HandlePause();
		}
		else 
		{
			MainPanel.SetActive(true);
			HandlePause();
		}
	}

	public void HandlePause()
	{
		if(Time.timeScale == 1f)
			Time.timeScale = 0f;
		else
			Time.timeScale = 1f;
	}
	
	public void ToggleOptionsPanel()
	{
		OptionsPanel.SetActive(!OptionsPanel.activeSelf);
	}
	
	public void Save()
	{
		SaveLoadController.SavePlayerPosition(Player.position);
	}
	
	public void Quit()
	{
		Application.LoadLevel("MainMenu");
	}
	
	public void ToggleMouseControlOption()
	{
		SaveLoadController.SetMouseControl(MouseControlToggle.isOn);
	}
	
	public void ToggleInversionOption()
	{
		SaveLoadController.SetYAxisInversion(InvertedYAxis.isOn);
	}
}
