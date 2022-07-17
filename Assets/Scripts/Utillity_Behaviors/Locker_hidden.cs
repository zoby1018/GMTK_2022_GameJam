using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Locker_hidden : UtillityOptions
{
    public override void Option1()
    {
        _utillityRef._dialogueHandlerRef._hotbar.PrepInventoryForLoad();
        SceneManager.LoadScene("Shipping");
    }

    public override void Option2()
    {
        _utillityRef._dialogueHandlerRef.OpenDialogue("Yeah it probably leads somewhere dangerous", null, 4);

    }
}
