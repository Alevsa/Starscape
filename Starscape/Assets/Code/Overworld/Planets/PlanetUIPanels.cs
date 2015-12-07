using UnityEngine;
using System.Collections;

public class PlanetUIPanels : MonoBehaviour
{
    public GameObject[] Panels;

    public void ChangePanel(GameObject panel)
    {
        foreach (GameObject pan in Panels)
        {
            pan.SetActive(false);
        }

        panel.SetActive(true);
    }
}
