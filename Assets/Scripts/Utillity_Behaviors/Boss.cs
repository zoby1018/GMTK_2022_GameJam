using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : UtillityOptions
{
    public override void OutputOption(Item item)
    {
        if (item.Name == "Coffee")
        {

            _utillityRef._dialogueHandlerRef._playerRef._coffee = true;
            SceneManager.LoadScene("End");

        }
        else if (item.Name == "Liquid")
        {
            _utillityRef._dialogueHandlerRef._playerRef._insane = true;
            SceneManager.LoadScene("End");
        }
        else if (item.Name == "Charged Battery")
        {
            _utillityRef._dialogueHandlerRef._playerRef._mercy = true;
            SceneManager.LoadScene("End");
        }
        else
        {
            int var = Random.Range(0, 100);
            if(var <= 10)
            {
                _utillityRef._dialogueHandlerRef._playerRef._rollOfDice = true;
                SceneManager.LoadScene("End");
            }
            else
            {
                _utillityRef._dialogueHandlerRef._playerRef._noCoffee = true;
                SceneManager.LoadScene("End");
            }
        }

    }
}
