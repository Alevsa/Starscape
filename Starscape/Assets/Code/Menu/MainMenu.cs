using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GameObject CreditsPanel = null;
	public GameObject OptionsPanel = null;
	public GameObject NewGamePanel = null;
	public GameObject LoadPanel = null;
	public GameObject QuitPanel = null;
	public string[] slotNames = null;
	public Text[] LoadSlotText = null;
	public Text[] SaveSlotText = null;
	
	void Start()
	{
		for (int i = 0; i < 3; i++)
		{
			SaveLoadController.SetSaveSlot(i);
			SaveSlotText[i].text = SaveLoadController.GetPlayerName().ToUpper();
			LoadSlotText[i].text = SaveLoadController.GetPlayerName().ToUpper();
		}
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
		SaveLoadController.EraseSaveSlot(slot);
		SaveLoadController.SavePlayerPosition(new Vector3(0,0,0));
		SaveLoadController.SetPlayerName("Jack Example");
		Application.LoadLevel("Overworld");
	}
	
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
		NewGamePanel.SetActive(false);
		LoadPanel.SetActive(false);
		QuitPanel.SetActive(false);
	}
	// Make it ask if you're sure
	public void Quit()
	{
		Application.Quit();
	}
}
