using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OverworldController : MonoBehaviour 
{
	public GameObject Player;
	public PauseMenu PauseMenuController;
    private OverworldMovement m_HandlerMovement;
    private bool m_MoveInUse = false;

    public GameObject EnterPanel;
    public GameObject MainPanel;
    public Text TitleText;
    public Text DescriptionText;
    private UpdateText m_EnterText;
    private GameObject m_CurrentPlanet;
    private LoadPlanetInfo m_PlanetInfo;
    private bool m_MainActive;
	private bool m_Docked;

	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		m_HandlerMovement = Player.GetComponent<OverworldMovement>();
		Player.transform.position = SaveLoadController.GetSavedPlayerPosition();
        m_EnterText = EnterPanel.transform.FindChild("EnterText").GetComponent<UpdateText>();
        m_PlanetInfo = new LoadPlanetInfo();
    }
	
	void Update () 
	{
		InGameInput ();
	}
	
	//In-game handling
	void InGameInput() 
	{	
		if (Input.GetAxisRaw("Turn") != 0f)
			m_HandlerMovement.Turn(Input.GetAxisRaw("Turn"));
		else
			m_HandlerMovement.Turn(Input.GetAxis("Horizontal"));
		
		#region Acceleration that only triggers on button press
		if (Input.GetAxisRaw("Accelerate") != 0)
		{
			if(m_MoveInUse == false)
			{
				m_HandlerMovement.AccelerationHandler(Input.GetAxisRaw("Accelerate"));
				m_MoveInUse = true;
			}
		}
		if (Input.GetAxisRaw("Accelerate") == 0)
		{
			m_MoveInUse = false;
		}

        #endregion

        if (Input.GetButtonDown("Pause"))
			PauseMenuController.TogglePauseMenu();

        if (Input.GetButtonDown("Dock"))
		{
            if (m_CurrentPlanet != null)
			{
				if(!m_Docked)
				{
					HandleOpen();
				}

				else
				{
					HandleClose ();
				}

			}
		}
    }

	public void HandleOpen()
	{
		OpenPlanetPane();
		PauseMenuController.HandlePause();
		m_Docked = true;
	}
	
	public void HandleClose()
	{
		ClosePlanetPane();
		PauseMenuController.HandlePause();
		m_Docked = false;
	}
	
	public void SetPlanet(GameObject planet)
    {
        m_CurrentPlanet = planet;
        m_EnterText.SetText(planet.name);
        if(!m_MainActive)
            EnterPanel.SetActive(true);
    }

    public void RemovePlanet()
    {
        m_CurrentPlanet = null;
        EnterPanel.SetActive(false);
        MainPanel.SetActive(false);
        m_MainActive = false;
    }

    private void OpenPlanetPane()
    {
        m_MainActive = true;
        EnterPanel.SetActive(false);
        TitleText.text = m_CurrentPlanet.name;
        DescriptionText.text = m_PlanetInfo.GetPlanetInfo(m_CurrentPlanet.name);
        MainPanel.SetActive(true);
    }

	private void ClosePlanetPane()
	{
		m_MainActive = false;
		EnterPanel.SetActive(true);
		MainPanel.SetActive(false);
	}
}
