using UnityEngine;
using System.Collections;
using System.Xml;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    private XmlDocument m_DialogueChain;
    public string DialoguePath = "TestDialogue.xml";
    public bool OverworldDialgue = false;
    public float DialogueSpeed = 2f;
    private XmlNodeList m_DialogueLines;
    public GameObject DialogueUI;
    public Image CharacterPortrait;
    public Text DialogueText;
    private bool m_DrawingText = false;
    public float Delay = 2f;
    public Text NameText;

    void Start()
    {
        DialogueSpeed = SaveLoadController.GetDialogueSpeed();
        m_DialogueChain = new XmlDocument();
    }

    public void LoadDialogue(string path)
    {
        DialoguePath = path;
        DialoguePath = "Assets/Resources/Text/Dialogue/" + DialoguePath;
        m_DialogueChain.Load(DialoguePath);
        m_DialogueLines = m_DialogueChain.SelectNodes("/root/line");
        PlayDialogue();
    }

    public void PlayDialogue()
    {
        DialogueUI.SetActive(true);
        StartCoroutine("PlayDialogueLine", 0);
        Resources.UnloadUnusedAssets();
    }

    IEnumerator PlayDialogueLine(int index)
    {
        XmlNode x = m_DialogueLines[index];
        string text = x.InnerXml;
        string portrait = x.Attributes["portrait"].Value;
        portrait = "Art/Portraits/" + portrait;
        Sprite img = Resources.Load<Sprite>(portrait);
        CharacterPortrait.sprite = img;
        text = StringProcessor.ProcessString(text);
        NameText.text = StringProcessor.ProcessString(x.Attributes["speakerName"].Value);
        Debug.Log(img); Debug.Log(portrait);
        for (int i = 0; i < text.Length; i++)
        {
            DialogueText.text = text.Substring(0, i + 1);
            yield return new WaitForSeconds(DialogueSpeed);
        }
        yield return new WaitForSeconds(Delay);
        DialogueText.text = "";
        CharacterPortrait.sprite = null;
        NameText.text = "";

        if (m_DialogueLines[index + 1] != null)
        {
            StartCoroutine("PlayDialogueLine", index + 1);
        }
        else
        {
            DialogueUI.SetActive(false);
        }
    }
}
