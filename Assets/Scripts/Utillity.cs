using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Utillity : MonoBehaviour
{
    [SerializeField] public string _dialogue;
    [SerializeField] private string _phase2Dialogue;
    [SerializeField] private Item _outputItem;
    [SerializeField] private int _interactionMode;
    //1 == outputs item
    //2 == item conversion
    //3 == dialogue with 2 choices
    //4 == Just text
    //5 == Requires input, then gives a result
    //6 == Elevator
    //7 == Door

    //10 == Liquid

    [SerializeField] private bool _isVending;
    [SerializeField] private GameObject _toast;
    [SerializeField] private TextMeshProUGUI _toastText;
    private bool _firstClick = false;
    [SerializeField]private string _toatDialogue;
    [SerializeField]private bool _doesAToast;

    public bool IsVending => _isVending;
    [SerializeField]private bool _oneTimeInventory;
    [SerializeField]private int _stock;

    [SerializeField] public List<string> _requiredInput = new List<string>();
    [SerializeField] private List<Item> _outputs = new List<Item>();


    [HideInInspector]public DialogueHandler _dialogueHandlerRef;
    private UtillityOptions _uoptions;

    [SerializeField] private string _option1;
    [HideInInspector] public string Option1Text => _option1;
    [SerializeField] private string _option2;
    [HideInInspector] public string Option2Text => _option2;


    [SerializeField] private Utillity _liquidContainer;

    // Start is called before the first frame update
    void Start()
    {
        _dialogueHandlerRef = FindObjectOfType<DialogueHandler>();
        _uoptions = GetComponent<UtillityOptions>();

        if (_doesAToast)
        {
            _toast.SetActive(true);
            _toastText.text = _toatDialogue;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUtillityClick()
    {
        _firstClick = true;
        _toast.SetActive(false);

        if(_oneTimeInventory && _stock > 0)
        {
            _dialogueHandlerRef.SetSelectedUitillity(this);
            _dialogueHandlerRef.OpenDialogue(_dialogue, _outputItem, _interactionMode);
            return;
        }
        else if(_oneTimeInventory && _stock <= 0)
        {
            _dialogueHandlerRef.SetSelectedUitillity(this);
            _dialogueHandlerRef.OpenDialogue(_phase2Dialogue, _outputItem, 4);
        }
        else if(!_oneTimeInventory)
        {
            _dialogueHandlerRef.SetSelectedUitillity(this);
            _dialogueHandlerRef.OpenDialogue(_dialogue, _outputItem, _interactionMode);
            return;
        }
        
        
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
            Debug.Log("Prerequisite met converting item");
            _outputItem = _outputs[Random.Range(0, _outputs.Count)];
            //_outputItem = _outputs[0];
            _dialogueHandlerRef.OpenDialogue(_dialogue, _outputItem, _interactionMode);
            _outputItem = null;
        }
    }

    public void PiplineBlood()
    {
        _outputItem = _outputs[Random.Range(0, _outputs.Count)];
        //_outputItem = _outputs[0];
        _dialogueHandlerRef.OpenDialogue(_dialogue, _outputItem, _interactionMode);
        _outputItem = null;
    }

    public void OutputFromItem(Item item)
    {
        Debug.Log("Item output: " + item.Name);
        _uoptions.OutputOption(item);
    }

    public void TriggerOption1()
    {
        _uoptions.Option1();
    }

    public void TriggerOption2()
    {
        _uoptions.Option2();
    }

    public void Liquidate()
    {
        Utillity newU = Instantiate(_liquidContainer);
        newU.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }

    public bool CheckIfRequiredInput(Item item)
    {
        for(int i=0; i<_requiredInput.Count; i++)
        {
            if(item.Name == _requiredInput[i])
            {
                return true;
            }
        }

        return false;
    }
}
