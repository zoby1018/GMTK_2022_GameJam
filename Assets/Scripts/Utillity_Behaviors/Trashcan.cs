using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trashcan : UtillityOptions
{
    public override void OutputOption(Item item)
    {
        if (item.Name == "Charged Battery")
        {
            _utillityRef._dialogueHandlerRef._hotbar.PrepInventoryForLoad();
            SceneManager.LoadScene("Storage");
        }
        else if (item.Name == "Liquidator")
        {
            _utillityRef._dialogueHandlerRef.CloseDialogue();
            _utillityRef.Liquidate();
        }

    }
}
