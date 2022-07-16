using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utillity : MonoBehaviour
{
    [SerializeField] private string _dialogue;
    [SerializeField] private Item _outputItem;
    [SerializeField] private bool _isPipeline;

    [SerializeField] private bool _isVending;
    public bool IsVending => _isVending;
    [SerializeField]private bool _oneTimeInventory;
    [SerializeField]private int _stock;

    [SerializeField] private List<string> _requiredInput = new List<string>();
    [SerializeField] private List<Item> _outputs = new List<Item>();


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
        _dialogueHandlerRef.SetSelectedUitillity(this);
        _dialogueHandlerRef.OpenDialogue(_dialogue, _outputItem, _isPipeline);
        
    }

    public bool Checkstock()
    {
        if (_oneTimeInventory)
        {
            if(_stock > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }

    public void RemoveStock()
    {
        _stock -= 1;
    }

    public void PipelineConversion(Item item)
    {
        
        if (_requiredInput.Contains(item.Name))
        {
            
            //_outputItem = _outputs[Random.Range(0, _outputs.Count)];
            _outputItem = _outputs[0];
            _dialogueHandlerRef.OpenDialogue(_dialogue, _outputItem, _isPipeline);
        }
    }
}
