using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catto : UtillityOptions
{
    public override void OutputOption(Item item)
    {
        if (item.Name == "Safety Knife")
        {
            _utillityRef._dialogueHandlerRef.OpenDialogue("Thanks now I'm going to check out what they're hiding in storage.", _reward, 1);
        }
        else if (item.Name == "Liquidator")
        {
            _utillityRef._dialogueHandlerRef.CloseDialogue();
            _utillityRef.Liquidate();
        }

    }
}
