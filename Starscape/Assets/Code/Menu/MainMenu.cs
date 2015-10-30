using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GameObject CreditsPanel = null;
	public GameObject OptionsPanel = null;
	public GameObject PlayPanel = null;
	public GameObject QuitPanel = null;
	
	public Button[] PlayButtons = null;
	public InputField[] PlayInputs = null;
	private int m_ActiveInputField;
	
	void Start()
	{
		for (int i = 0; i < 3; i++)
		{
			SaveLoadController.SetSaveSlot(i);
		}
		InitialisePlayPanel();
	}
	
	void Update()
	{
		InputFieldControl();
	}
	
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

	public void NewGame(int slot)
	{
		SaveLoadController.SetSaveSlot(slot);
		SaveLoadController.SavePlayerPosition(new Vector3(0,0,0));
		SaveLoadController.SetPlayerName(PlayInputs[slot].text);
		InitialisePlayPanel();
	}
	
	// Fix this
	public void LoadGame(int slot)
	{
		if (SaveLoadController.GetPlayerName() != "EMPTY SLOT")
		{
			SaveLoadController.SetSaveSlot(slot);
			Application.LoadLevel("Overworld");
		}
	}
	
	public void CloseAllWindows()
	{
		CreditsPanel.SetActive(false);
		OptionsPanel.SetActive(false);
		PlayPanel.SetActive(false);
		QuitPanel.SetActive(false);
	}
	
	public void InitialisePlayPanel()
	{
		for (int i = 0; i < 3; i++)
		{
			SaveLoadController.SetSaveSlot(i);
			if (SaveLoadController.GetPlayerName() == "")
			{
				PlayButtons[i].gameObject.SetActive(false);
				PlayInputs[i].placeholder.GetComponent<Text>().text = "EMPTY SLOT";
				PlayInputs[i].gameObject.SetActive(true);
			}
			else 
			{
				PlayButtons[i].gameObject.SetActive(true);
				PlayButtons[i].GetComponentInChildren<Text>().text = SaveLoadController.GetPlayerName();
				PlayInputs[i].gameObject.SetActive(false);
			}
		}
	}
	
	public void InputFieldControl()
	{		
		bool inputFocused = false;
		for (int i = 0; i < 3; i++)
		{
			if (PlayInputs[i].isFocused)
			{
				m_ActiveInputField = i;
				inputFocused = true;
			}
		}
		if (Input.GetButtonDown("Submit") && inputFocused)
		{
			NewGame(m_ActiveInputField);
		}
	}
	
	public void DeleteFile(int slot)
	{
		SaveLoadController.SetSaveSlot(slot);
		SaveLoadController.EraseSaveSlot(slot);
		InitialisePlayPanel();
	}
	// Make it ask if you're sure
	public void Quit()
	{
		Application.Quit();
	}
}
