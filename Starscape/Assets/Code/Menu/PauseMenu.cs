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

    public bool Paused { get; private set; }

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
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            Paused = true;
        }
        else
        {
            Time.timeScale = 1f;
            Paused = false;
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
