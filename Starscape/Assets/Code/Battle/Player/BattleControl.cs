using UnityEngine;
using System.Collections;

public class BattleControl : MonoBehaviour 
{	
	//Ship to be controlled
	public GameObject Ship;
	private BattleMovement m_HandlerMovement;
	public BattleCamera m_HandlerCamera;
	private float m_RotDamping;
	public float Deadzone = 0.05f;
	public PauseMenu PauseMenuController;

    private WeaponController m_PlayerWeapons;
	
	// Use this for initialization
	void Start () 
	{
		Ship = GameObject.FindGameObjectWithTag("PlayerBattle");
		m_HandlerMovement = Ship.GetComponent<BattleMovement>();
        m_PlayerWeapons = Ship.GetComponent<WeaponController>();
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (Ship != null)
			InGameInput ();
	}
	
	void MenuInput() {
		
	}
	
	//In-game handling
	void InGameInput() 
	{
		if (Input.GetAxisRaw("Battle Accelerate") < 0f)
			m_HandlerMovement.Decelerate();
		else if (Input.GetAxisRaw("Battle Accelerate") > 0f)
			m_HandlerMovement.Accelerate();
		else if (Input.GetAxisRaw("Hand Brake") == 1f)
			m_HandlerMovement.HandBrake();		
		
		m_HandlerMovement.RollMagnitude = Input.GetAxisRaw("Roll");
		
		if (Input.GetButtonDown("Rear View"))
			m_HandlerCamera.Flip();
			
		if (Input.GetButton("Stabilise"))
			m_HandlerMovement.StabiliserActive = true;
		else	
			m_HandlerMovement.StabiliserActive = false;
		
		if (SaveLoadController.GetMouseControl())
			m_HandlerMovement.PitchYaw(MouseXToJoyStickAxis(), MouseYToJoyStickAxis() * SaveLoadController.GetYAxisInversion());
		else
			m_HandlerMovement.PitchYaw(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") * SaveLoadController.GetYAxisInversion());

        if (Input.GetButtonDown("Fire"))
            m_PlayerWeapons.FirePrimaryWeaponTap();
        if (Input.GetButton("Fire"))
            m_PlayerWeapons.FirePrimaryWeaponHold();

        if (Input.GetButtonDown("Pause"))
			PauseMenuController.TogglePauseMenu();
    }
	
	#region Converts mouse coordinates to joystick input, imagine the mouse cursor as the top of the joystick, that's how it works.
	float MouseYToJoyStickAxis()
	{
		float y = -1f * (((Input.mousePosition.y - (0.5f * Screen.height)) / Screen.height) * 2f);  
		if (Mathf.Abs(y) < Deadzone)
			return 0;
		else return y;
	}
	
	float MouseXToJoyStickAxis()
	{
		float x = (((Input.mousePosition.x - (0.5f * Screen.width)) / Screen.width) * 2f);  
		if (Mathf.Abs(x) < Deadzone)
			return 0;
		else return x;
	}
	#endregion
}
