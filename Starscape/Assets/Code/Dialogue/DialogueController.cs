using UnityEngine;
using System.Collections;
using System.Xml;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    private XmlDocument m_DialogueChain;
    public string DialoguePath = "TestDialogue.xml";
    public bool OverworldDialgue = false;
    public float DialogueSpeed = 1f;
    private XmlNodeList m_DialogueLines;
    public GameObject DialogueUI;
    public Image CharacterPortrait;
    public Text DialogueText;

    void Start()
    {
        DialogueSpeed = SaveLoadController.GetDialogueSpeed();
        DialoguePath = "Assets/Text/Dialogue/" + DialoguePath;
        m_DialogueChain = new XmlDocument();
        m_DialogueChain.Load(DialoguePath);
        m_DialogueLines = m_DialogueChain.SelectNodes("/root/node");
    }

    void PlayDialogue()
    {
        DialogueText.text = "";
        CharacterPortrait.sprite = null;
        DialogueUI.SetActive(true);
        foreach (XmlNode node in m_DialogueLines)
        {
            PlayDialogueLine(node);
        }
    }

    void PlayDialogueLine(XmlNode x)
    {
        string text = x.Value;
        string portrait = x.Attributes["portrait"].Value;
        portrait = "Assets/Art/Portraits/" + portrait;
        string name = x.Attributes["speakerName"].Value;

        //open sprite for portrait and slap on the character iamge thing

        for (float i = 0; i < text.Length * DialogueSpeed; i += DialogueSpeed)
        {
            Invoke("AddNextCharacter", i);
        }
        // Delay before next stage
    }

    void AddNextCharacter()
    {
        DialogueText.text += "";
    }
}
