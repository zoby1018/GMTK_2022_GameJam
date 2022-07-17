using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : UtillityOptions
{
    public override void OutputOption(Item item)
    {
        if (item.Name == "Screwdriver")
        {
            _utillityRef._dialogueHandlerRef._hotbar.ChargeBatteries();
            _utillityRef._dialogueHandlerRef.OpenDialogue("Batteries in your inventory were charged!", _reward, 1);
        }

    }
}
