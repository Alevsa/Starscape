using UnityEngine;
using System.Collections;

public static class SaveLoadController 
{	
	public static void SavePlayerPosition (Vector3 pos)
	{
		PlayerPrefs.SetFloat ("pXpos", pos.x);
		PlayerPrefs.SetFloat ("pYpos", pos.y);
		PlayerPrefs.SetFloat ("pZpos", pos.z);
	}

	public static Vector3 GetSavedPlayerPosition ()
	{
		Vector3 res;
		res.x = PlayerPrefs.GetFloat ("pXpos");
		res.y = PlayerPrefs.GetFloat ("pYpos");
		res.z = PlayerPrefs.GetFloat ("pZpos");

		return res;
	}

	public static void SavePlayerHealth (string partName, float health)
	{
		PlayerPrefs.SetFloat ("p" + partName + "Health", health);
	}

	public static float GetPlayerHealth (string partName)
	{
		float res = PlayerPrefs.GetFloat ("p" + partName + "Health");

		return res;
	}
}
