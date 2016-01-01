using UnityEngine;
using System.Collections;

public class TimedDialogueEvent : TimedEvent
{
    public string Dialogue = "TestDialogue.xml";

    public override void Fire()
    {
        gameObject.GetComponentInParent<DialogueController>().LoadDialogue(Dialogue);
    }
}
