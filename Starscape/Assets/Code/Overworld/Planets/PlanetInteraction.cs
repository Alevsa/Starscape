using UnityEngine;

public class PlanetInteraction : MonoBehaviour
{
    private OverworldController m_Controller;

    void Start()
    {
        m_Controller = GameObject.Find("Controller").GetComponent<OverworldController>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
            m_Controller.SetPlanet(gameObject);
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
            m_Controller.RemovePlanet();
    }
}
