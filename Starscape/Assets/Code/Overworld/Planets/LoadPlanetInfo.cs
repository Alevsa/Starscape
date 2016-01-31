using UnityEngine;
using System.Collections;
using System.Xml;

public class LoadPlanetInfo
{
    private XmlDocument m_PlanetInfo;
    public StageDirector stageDirector;
    public LoadPlanetInfo()
    {
        m_PlanetInfo = new XmlDocument();
        m_PlanetInfo.Load("Assets/Resources/Text/Planets/PlanetInformation");
    }

    public string GetPlanetInfo(string planetName)
    {
        XmlNode node = m_PlanetInfo.SelectSingleNode("/root/planet[@id='" + planetName + "']");
        string description = node.InnerText;
        return description;
    }

    public void PopulateMissionPanel(string planetName, ref GameObject MissionPanel)
    {
        int[] missions = GetPlanetMissions(planetName);
        // set up mission panel with proper missions
    }

    public int[] GetPlanetMissions(string planetName)
    {
        int limit = stageDirector.GetActiveStage();
        for (int i = 0; i < limit; i++)
        {
            if (stageDirector.Stages[i].name == planetName)
            {
                // Add stage to mission list
            }
        }
        return new int[0];
    }
}
