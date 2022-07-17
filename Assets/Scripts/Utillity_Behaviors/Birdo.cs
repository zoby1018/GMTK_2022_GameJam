using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdo : UtillityOptions
{
    public override void OutputOption(Item item)
    {
        if (item.Name == "Tool Voucher")
        {
            _utillityRef._dialogueHandlerRef.OpenDialogue("Thanks I didn't want to have to donate blood.", _reward, 1);
        }
        else if (item.Name == "Liquidator")
        {
            _utillityRef._dialogueHandlerRef.CloseDialogue();
            _utillityRef.Liquidate();
        }

    }
}
