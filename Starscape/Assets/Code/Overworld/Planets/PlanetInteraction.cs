using UnityEngine;
using System.Collections;

public class PlanetInteraction : MonoBehaviour
{
    public GameObject m_EnterPanel;
    private UpdateText m_EnterText;

    void Start()
    {
        m_EnterText = m_EnterPanel.transform.FindChild("EnterText").GetComponent<UpdateText>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            m_EnterText.SetText(gameObject.name);
            m_EnterPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            m_EnterPanel.SetActive(false);
        }
    }
}
