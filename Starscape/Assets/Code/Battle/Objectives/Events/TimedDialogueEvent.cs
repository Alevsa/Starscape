using UnityEngine;
using System.Collections;

public class TimedDialogueEvent : TimedEvent
{
    public string Dialogue = "TestDialogue.xml";

    public override void Fire()
    {
        Debug.Log("Fired Dialogue Event");
        gameObject.GetComponentInParent<DialogueController>().LoadDialogue(Dialogue);
    }
}
