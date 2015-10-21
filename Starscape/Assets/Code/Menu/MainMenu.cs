using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public void NewGame()
	{
		Application.LoadLevel("Overworld");
	}
	
	public void Load()
	{
	
	}
	
	public void Options()
	{
	
	}
	
	// Make it ask if you're sure
	public void Quit()
	{
		Application.Quit();
	}
}
