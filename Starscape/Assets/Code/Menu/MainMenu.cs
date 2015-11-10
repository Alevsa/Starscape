using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public GameObject CreditsPanel = null;
	public GameObject OptionsPanel = null;
	public GameObject PlayPanel = null;
	public GameObject QuitPanel = null;
	
	public Toggle MouseControlToggle = null;
	public Toggle InvertedYAxis = null;
	public Button[] PlayButtons = null;
	public InputField[] PlayInputs = null;
	private int m_ActiveInputField;

    private GameObject m_CurrentPanel;
    private bool m_Status;
	
	void Start()
	{
		for (int i = 0; i < 3; i++)
		{
			SaveLoadController.SetSaveSlot(i);
		}
		if (SaveLoadController.GetYAxisInversion() == -1)
			InvertedYAxis.isOn = true;
		else 
			InvertedYAxis.isOn = false;
		
		if (SaveLoadController.GetMouseControl())
			MouseControlToggle.isOn = true;
		else
			MouseControlToggle.isOn = false;		
		InitialisePlayPanel();
	}
	
	void Update()
	{
		InputFieldControl();
	}
	
	public void TogglePanel(GameObject panel)
	{

        if (m_CurrentPanel != panel)
        {
            if (m_CurrentPanel == null)
            {
                panel.GetComponent<Animator>().SetBool("SlideIn", true);
            }

            else
            {
                m_CurrentPanel.transform.SetAsFirstSibling();
                m_CurrentPanel.GetComponent<Animator>().SetBool("SlideIn", false);

                panel.transform.SetAsLastSibling();
                panel.GetComponent<Animator>().SetBool("SlideIn", true);
            }

            m_CurrentPanel = panel;
            m_Status = true;
        }

        else
        {
            m_CurrentPanel.GetComponent<Animator>().SetBool("SlideIn", m_Status);
            m_Status = !m_Status;
        }
	}

	public void NewGame(int slot)
	{
		SaveLoadController.SetSaveSlot(slot);
		SaveLoadController.SavePlayerPosition(new Vector3(0,0,0));
		SaveLoadController.SetPlayerName(PlayInputs[slot].text);
		InitialisePlayPanel();
	}

	public void LoadGame(int slot)
	{
		if (SaveLoadController.GetPlayerName() != "EMPTY SLOT")
		{
			SaveLoadController.SetSaveSlot(slot);
			Application.LoadLevel("Overworld");
		}
	}
	
	public void InitialisePlayPanel()
	{
		bool initialState = PlayPanel.activeSelf;
		PlayPanel.SetActive(true);
		for (int i = 0; i < 3; i++)
		{
			Debug.Log(i);
			Debug.Log(SaveLoadController.GetPlayerName());
			SaveLoadController.SetSaveSlot(i);
			if (SaveLoadController.GetPlayerName() == "")
			{
				Debug.Log("Blank slot");
				PlayButtons[i].gameObject.SetActive(false);
				PlayInputs[i].placeholder.GetComponent<Text>().text = "EMPTY SLOT";
				PlayInputs[i].gameObject.SetActive(true);
			}
			else 
			{
				Debug.Log("There's something here");
				PlayButtons[i].gameObject.SetActive(true);
				PlayButtons[i].GetComponentInChildren<Text>().text = SaveLoadController.GetPlayerName();
				PlayInputs[i].gameObject.SetActive(false);
			}
		}
		PlayPanel.SetActive(initialState);
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
	
	public void ToggleMouseControlOption()
	{
		SaveLoadController.SetMouseControl(MouseControlToggle.isOn);
	}
	
	public void ToggleInversionOption()
	{
		SaveLoadController.SetYAxisInversion(InvertedYAxis.isOn);
	}
	
	// Make it ask if you're sure
	public void Quit()
	{
		Application.Quit();
	}
}
