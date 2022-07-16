using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    private Item _input;
    private Item _output;
    private string _text;

    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] public Transform _outputContainer;
    [SerializeField] public Transform _inputContainer;
    [SerializeField] private Button _confirmButton;

    [SerializeField] private Hotbar _hotbar;

    private DialogueHandler _dialogueHandlerRef;

    private void Awake()
    {
        _dialogueHandlerRef = FindObjectOfType<DialogueHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateDialogue(string text, Item output, bool pipeline)
    {
        DestroyInput();

        if (!pipeline)
        {
            _dialogueText.text = text;
            _outputContainer.localPosition = new Vector3(0, -100, 0);
            _inputContainer.gameObject.SetActive(false);
            _confirmButton.gameObject.SetActive(false);

            if (output != null)
            {
                if (_dialogueHandlerRef._selectedUtillity.Checkstock())
                {
                    Item item = Item.Instantiate(output);
                    item.transform.SetParent(_outputContainer);
                    item.transform.position = _outputContainer.transform.position;
                    item.setStartingPosition(_outputContainer.transform.position);
                    _output = item;
                }
                
            }
        }
        else if (pipeline)
        {
            _dialogueText.text = text;
            _outputContainer.localPosition = new Vector3(120, -50, 0);
            _inputContainer.localPosition = new Vector3(-120, -50, 0);
            _confirmButton.gameObject.SetActive(true);
            _inputContainer.gameObject.SetActive(true);

            if (output != null)
            {
                
                    Item item = Item.Instantiate(output);
                    item.transform.SetParent(_outputContainer);
                    item.transform.position = _outputContainer.transform.position;
                    item.setStartingPosition(_outputContainer.transform.position);
                    _output = item;
                

            }

        }
    }

    public void CloseDialogue()
    {
        if(_output != null)
        {
            if (!_hotbar._inventory.Contains(_output))
            {
                _output = null;
                Destroy(_output.gameObject);
            }
           
        }

        
    }

    public void DestroyInput()
    {
        if(_input != null)
        {
            _hotbar.RemoveItem(_input);
            Destroy(_input.gameObject);
            _input = null;
        }
       
    }

    public void ClearInput()
    {
        Debug.Log("Clear Input Called");
        _input = null;
    }

    public void ConfirmButtonPressed()
    {
        Debug.Log("Button Was Pressed");
        if(_input != null)
        {
            if (_dialogueHandlerRef._selectedUtillity.IsVending)
            {
                _dialogueHandlerRef._selectedUtillity.PipelineConversion(_input);
            }
        }

        
    }

    public void setInput(Item item)
    {
        _input = item;
    }
}
