using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedVent : UtillityOptions
{
    public override void OutputOption(Item item)
    {
        if (item.Name == "Screwdriver")
        {
            SceneManager.LoadScene(_utillityRef._dialogue);
        }

    }
}
