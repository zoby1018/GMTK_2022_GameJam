using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alex_Options : UtillityOptions
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Option1()
    {
        _utillityRef._dialogueHandlerRef._playerRef.TakeDamage(15);
        _utillityRef._dialogueHandlerRef.OpenDialogue("Alex Bites you dealing 15 damage.", null, 4);
    }

    public override void Option2()
    {
        _utillityRef._dialogueHandlerRef.OpenDialogue("You Aight.", null, 4);

    }
}
