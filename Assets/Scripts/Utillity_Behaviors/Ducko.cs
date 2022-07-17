using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ducko : UtillityOptions
{
    public override void OutputOption(Item item)
    {
        if (item.Name == "Charged Battery")
        {
            _utillityRef._dialogueHandlerRef.OpenDialogue("Thanks I can finally get the fire control station running. It's been" +
                " about 3 months since it had power.", _reward, 1);
        }
        else if (item.Name == "Liquidator")
        {
            _utillityRef._dialogueHandlerRef.CloseDialogue();
            _utillityRef.Liquidate();
        }

    }
}
