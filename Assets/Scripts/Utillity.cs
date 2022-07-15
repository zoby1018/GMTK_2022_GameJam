using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utillity : MonoBehaviour
{
    [SerializeField] private string _dialogue;
    [SerializeField] private Item _outputItem;
    [SerializeField] private bool _isPipeline;


    private DialogueHandler _dialogueHandlerRef;

    // Start is called before the first frame update
    void Start()
    {
        _dialogueHandlerRef = FindObjectOfType<DialogueHandler>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUtillityClick()
    {
        _dialogueHandlerRef.OpenDialogue(_dialogue, _outputItem, _isPipeline);
        _dialogueHandlerRef.SetSelectedUitillity(this);
    }
}
