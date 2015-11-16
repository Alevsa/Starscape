using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateText : MonoBehaviour
{
    public string DisplayMessage = "Dock with ";

    public void SetText(string text)
    {
       GetComponent<Text>().text = DisplayMessage + text;
    }
}
