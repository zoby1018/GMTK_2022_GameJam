using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koalo : UtillityOptions
{
    public override void OutputOption(Item item)
    {
        if (item.Name == "Box Cutter")
        {
            _utillityRef._dialogueHandlerRef.OpenDialogue("Cheers mate!", _reward, 1);
        }
        else if (item.Name == "Liquidator")
        {
            _utillityRef._dialogueHandlerRef.CloseDialogue();
            _utillityRef.Liquidate();
        }

    }
}
