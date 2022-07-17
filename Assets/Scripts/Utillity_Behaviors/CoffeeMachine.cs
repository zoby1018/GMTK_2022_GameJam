using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : UtillityOptions
{
    public override void OutputOption(Item item)
    {
        if (item.Name == "Empty Mug")
        {
            _utillityRef._dialogueHandlerRef.OpenDialogue("You got Coffee!", _reward, 1);

        }
       

    }
}
