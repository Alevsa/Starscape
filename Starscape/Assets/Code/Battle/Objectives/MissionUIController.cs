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
        if (inProgress)
        {
            inProgress = false;
            TimeStop();
            WinUI.SetActive(true);
            WinText.text = winText;
        }
    }

    public void Lose(string[] loseText)
    {
        TimeStop();
        if (inProgress)
        {
            inProgress = false;
            LoseUI.SetActive(true);
            foreach (string x in loseText)
            {
                LoseText.text += x;
            }
        }
    }

    private void TimeStop()
    {
        Debug.Log(Time.timeScale);
        if (Time.timeScale > 0)
        {
            Time.timeScale *= 0.01f;
        }
        if (Time.timeScale < 0.05f)
        {
            Time.timeScale = 0f;
        }
    }
    
}
