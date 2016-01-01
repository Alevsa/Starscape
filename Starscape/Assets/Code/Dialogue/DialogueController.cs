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
    private bool m_DrawingText = false;


    void Start()
    {
        DialogueSpeed = SaveLoadController.GetDialogueSpeed();
        DialoguePath = "Assets/Resources/Text/Dialogue/" + DialoguePath;
        m_DialogueChain = new XmlDocument();
        m_DialogueChain.Load(DialoguePath);
        m_DialogueLines = m_DialogueChain.SelectNodes("/root/line");
    }

    public void PlayDialogue()
    {
        DialogueUI.SetActive(true);
        foreach (XmlNode node in m_DialogueLines)
        {
            PlayDialogueLine(node);
        }
        //DialogueUI.SetActive(false);
        Resources.UnloadUnusedAssets();
    }

    void PlayDialogueLine(XmlNode x)
    {
        string text = x.InnerText;
        string portrait = x.Attributes["portrait"].Value;
        //portrait = "Art/Portraits/" + portrait;
        string name = x.Attributes["speakerName"].Value;
        Sprite img = Resources.Load<Sprite>(portrait);
        Debug.Log(img); Debug.Log(portrait);

        CharacterPortrait.sprite = img;

        DialogueText.text = text;
        //StartCoroutine("PlayText", text);
        
        // Delay before next stage
        //DialogueText.text = "";
        //CharacterPortrait.sprite = null;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
    }

    IEnumerator PlayText(string line)
    {
        for (int i = 0; i < line.Length; i++)
        {
            for (float j = 0; j < DialogueSpeed; j += Time.deltaTime)
            {
                DialogueText.text = line.Substring(0, i + 1);
                Debug.Log(DialogueText.text);
                yield return null;
            }
        }
    }
}
