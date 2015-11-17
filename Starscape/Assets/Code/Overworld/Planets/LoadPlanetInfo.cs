using UnityEngine;
using System.Collections;
using System.Xml;

public class LoadPlanetInfo
{
    private XmlDocument m_PlanetInfo;

    public LoadPlanetInfo()
    {
        m_PlanetInfo = new XmlDocument();
        m_PlanetInfo.Load("Assets/Text/Planets/PlanetInformation");
    }

    public string GetPlanetInfo(string planetName)
    {
        XmlNode node = m_PlanetInfo.SelectSingleNode("/root/planet[@id='" + planetName + "']");
        string description = node.InnerText;
        return description;
    }
}
