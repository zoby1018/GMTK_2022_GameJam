using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedDoor : UtillityOptions
{
    
    public override void OutputOption(Item item)
    {
        if (item.Name == "ID")
        {
            SceneManager.LoadScene(_utillityRef._dialogue);
        }

    }
}
