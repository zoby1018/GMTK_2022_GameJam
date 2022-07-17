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
            _utillityRef._dialogueHandlerRef.OpenDialogue("Now you look healthy as horse who should be getting back to work.", null, 4);
           
        }

    }
}
