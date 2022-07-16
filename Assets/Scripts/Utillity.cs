using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utillity : MonoBehaviour
{
    [SerializeField] private string _dialogue;
    [SerializeField] private Item _outputItem;
    [SerializeField] private int _interactionMode;
    //1 == outputs item
    //2 == item conversion
    //3 == dialogue with 2 choices
    //4 == Just text

    [SerializeField] private bool _isVending;
    public bool IsVending => _isVending;
    [SerializeField]private bool _oneTimeInventory;
    [SerializeField]private int _stock;

    [SerializeField] private List<string> _requiredInput = new List<string>();
    [SerializeField] private List<Item> _outputs = new List<Item>();


    [HideInInspector]public DialogueHandler _dialogueHandlerRef;
    private UtillityOptions _uoptions;

    [SerializeField] private string _option1;
    [HideInInspector] public string Option1Text => _option1;
    [SerializeField] private string _option2;
    [HideInInspector] public string Option2Text => _option2;

    // Start is called before the first frame update
    void Start()
    {
        _dialogueHandlerRef = FindObjectOfType<DialogueHandler>();
        _uoptions = GetComponent<UtillityOptions>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUtillityClick()
    {
        _dialogueHandlerRef.SetSelectedUitillity(this);
        _dialogueHandlerRef.OpenDialogue(_dialogue, _outputItem, _interactionMode);
        
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
            
            _outputItem = _outputs[Random.Range(0, _outputs.Count)];
            //_outputItem = _outputs[0];
            _dialogueHandlerRef.OpenDialogue(_dialogue, _outputItem, _interactionMode);
            _outputItem = null;
        }
    }

    public void TriggerOption1()
    {
        _uoptions.Option1();
    }

    public void TriggerOption2()
    {
        _uoptions.Option2();
    }
}
