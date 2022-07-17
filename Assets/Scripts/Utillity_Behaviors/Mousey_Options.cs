using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousey_Options : UtillityOptions
{
    

    // Update is called once per frame
    public override void OutputOption(Item item)
    {
        if(item.Name == "Medpack")
        {
            _utillityRef._dialogueHandlerRef.OpenDialogue("Thankyou! You can have this", _reward, 1);
            _utillityRef._dialogueHandlerRef._playerRef._mouseEnding = true;
        }
        else if(item.Name == "Liquidator")
        {
            _utillityRef._dialogueHandlerRef.CloseDialogue();
            _utillityRef.Liquidate();
        }

    }
}
