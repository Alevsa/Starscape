using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissionUIController : MonoBehaviour
{
    public Text WinText;
    public Text LoseText;
    public GameObject WinUI;
    public GameObject LoseUI;
    private bool inProgress = true;

    public void Win(string winText)
    {
        TimeStop();
        WinUI.SetActive(true);
        WinText.text = winText;
    }

    public void Lose(string[] loseText)
    {
        TimeStop();
        LoseUI.SetActive(true);
        foreach (string x in loseText)
        {
            LoseText.text += x;
        }
    }

    private void TimeStop()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale -= Time.deltaTime;
        }
    }
    
}
