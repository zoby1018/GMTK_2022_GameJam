using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker_Liquid : UtillityOptions
{
    public override void OutputOption(Item item)
    {
        if (item.Name == "Charged Battery")
        {
            _utillityRef._dialogueHandlerRef.OpenDialogue("What on Earth is this thing? Well it might be useful.", _reward, 1);
        }

    }
}
