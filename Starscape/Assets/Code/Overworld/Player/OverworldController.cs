using UnityEngine;
using System.Collections;

public class OverworldController : MonoBehaviour 
{
	//Ship to be controlled
	public GameObject Player;
	private OverworldMovement m_HandlerMovement;
	public PauseMenu PauseMenuController;
	private bool m_MoveInUse = false;

    public GameObject EnterPanel;
    public GameObject MainPanel;
    private UpdateText m_EnterText;
    private GameObject m_CurrentPlanet;
	
	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		m_HandlerMovement = Player.GetComponent<OverworldMovement>();
		Player.transform.position = SaveLoadController.GetSavedPlayerPosition();
        m_EnterText = EnterPanel.transform.FindChild("EnterText").GetComponent<UpdateText>();
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
            if (m_CurrentPlanet != null)
                OpenPlanetPane();
    }
    
    public void SetPlanet(GameObject planet)
    {
        m_CurrentPlanet = planet;
        m_EnterText.SetText(planet.name);
        EnterPanel.SetActive(true);
    }

    public void RemovePlanet()
    {
        m_CurrentPlanet = null;
        EnterPanel.SetActive(false);
        MainPanel.SetActive(false);
    }

    private void OpenPlanetPane()
    {
        EnterPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
}
