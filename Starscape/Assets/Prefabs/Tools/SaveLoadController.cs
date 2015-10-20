using UnityEngine;
using System.Collections;

public static class SaveLoadController {

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

	public static void SavePlayerHealth (float health)
	{
		PlayerPrefs.SetFloat ("pHealth", health);
	}

	public static float GetPlayerHealth ()
	{
		float res = PlayerPrefs.GetFloat ("pHealth");

		return res;
	}
}
