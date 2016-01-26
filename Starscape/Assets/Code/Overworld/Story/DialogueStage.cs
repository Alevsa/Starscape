using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueStage : IStage
{
    public GameObject DialogueUI;
    private DialogueController m_Dialogue;
    public string Path;
    public int? TargetStage;
    private bool Active = false;
    public OverworldController m_Controller;

    void Play()
    {
        if (TargetStage == null)
        {
            TargetStage = SaveLoadController.GetStoryStage() + 1;
        }
        SaveLoadController.SetStoryStage((int)TargetStage);
        transform.parent.GetComponent<DialogueController>();
        m_Dialogue.LoadDialogue(Path);
        m_Dialogue.PlayDialogue();
        DisableInput();
    }

    void DisableInput()
    {
        //m_Controller.
    }
}
