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
			Time.timeScale = 1f;
		}
		else 
		{
			MainPanel.SetActive(true);
			Time.timeScale = 0f;
		}
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
		Application.Quit();
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
