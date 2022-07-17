using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medbay : UtillityOptions
{
    public override void OutputOption(Item item)
    {
        if (item.Name == "Medpack")
        {
            _utillityRef._dialogueHandlerRef._playerRef.TakeDamage(-15);
            _utillityRef._dialogueHandlerRef.OpenDialogue("You regained some health.", null, 4);
           
        }

    }
}
