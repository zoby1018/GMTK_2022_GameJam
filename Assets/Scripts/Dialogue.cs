using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{

    private Item _input;
    private Item _output;
    private string _text;

    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] public Transform _outputContainer;
    [SerializeField] public Transform _inputContainer;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private Button _confirmForInput;
    [SerializeField] private Button _option_1;
    [SerializeField] private TextMeshProUGUI _option1Text;
    [SerializeField] private Button _option_2;
    [SerializeField] private TextMeshProUGUI _option2Text;
    [SerializeField] private Button _bloodCostButton;
    private bool _dialogueLocked;

    [SerializeField] private Hotbar _hotbar;

    [HideInInspector]private DialogueHandler _dialogueHandlerRef;

    private void Awake()
    {
        _dialogueHandlerRef = FindObjectOfType<DialogueHandler>();
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateDialogue(string text, Item output, int mode)
    {
        if(_dialogueLocked == false)
        {
            DestroyInput();
            _inputContainer.gameObject.SetActive(false);
            _outputContainer.gameObject.SetActive(false);
            _confirmButton.gameObject.SetActive(false);
            _option_1.gameObject.SetActive(false);
            _option_2.gameObject.SetActive(false);
            _confirmForInput.gameObject.SetActive(false);
            _bloodCostButton.gameObject.SetActive(false);

            if (mode == 1)
            {
                _dialogueText.text = text;
                _outputContainer.localPosition = new Vector3(0, -100, 0);
                _inputContainer.gameObject.SetActive(false);
                _confirmButton.gameObject.SetActive(false);
                _outputContainer.gameObject.SetActive(true);

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
            else if (mode == 2)
            {
                _dialogueText.text = text;
                _outputContainer.localPosition = new Vector3(120, -50, 0);
                _inputContainer.localPosition = new Vector3(-120, -50, 0);
                _confirmButton.gameObject.SetActive(true);
                _inputContainer.gameObject.SetActive(true);
                _outputContainer.gameObject.SetActive(true);
                _bloodCostButton.gameObject.SetActive(true);

                if (output != null)
                {

                    Item item = Item.Instantiate(output);
                    item.transform.SetParent(_outputContainer);
                    item.transform.position = _outputContainer.transform.position;
                    item.setStartingPosition(_outputContainer.transform.position);
                    _output = item;


                }

            }
            else if (mode == 3)
            {
                _dialogueText.text = text;
                _option1Text.text = _dialogueHandlerRef._selectedUtillity.Option1Text;
                _option2Text.text = _dialogueHandlerRef._selectedUtillity.Option2Text;
                _option_1.gameObject.SetActive(true);
                _option_2.gameObject.SetActive(true);
            }
            else if (mode == 4)
            {
                _dialogueText.text = text;

            }
            else if (mode == 5)
            {
                if (_dialogueHandlerRef._selectedUtillity.Checkstock())
                {
                    _dialogueText.text = text;
                    _inputContainer.localPosition = new Vector3(0, -85, 0);
                    _inputContainer.gameObject.SetActive(true);
                    _confirmForInput.gameObject.SetActive(true);
                }
            }
            else if (mode == 6)
            {

            }
            else if (mode == 7)
            {
                _hotbar.PrepInventoryForLoad();
                _dialogueLocked = true;
                SceneManager.LoadScene(text);
            }
        }

        
    }

    public void CloseDialogue()
    {
        if(_output != null)
        {
            if (!_hotbar._inventory.Contains(_output))
            {
               
                Destroy(_output.gameObject);
              
            }

            _output = null;
        }

        if(_input != null)
        {
            _input.CheckIfInInput();
            _input = null;
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
        Debug.Log("Conversion Button Was Pressed");
        if(_input == null)
        {
            Debug.Log("Input is null");
        }
        if(_input != null)
        {
            if (_dialogueHandlerRef._selectedUtillity.IsVending)
            {
                _dialogueHandlerRef._selectedUtillity.PipelineConversion(_input);
            }
        }

        
    }

    public void PayInBlood()
    {
        
            if (_dialogueHandlerRef._selectedUtillity.IsVending)
            {
                _dialogueHandlerRef._playerRef.TakeDamage(10);
            _dialogueHandlerRef._selectedUtillity.PiplineBlood();
            }
        

    }

    public void ConfirmForInput()
    {
        if(_input != null)
        {
            Debug.Log("Confirm for Input called");
            _dialogueHandlerRef._selectedUtillity.OutputFromItem(_input);
        }
    }

    public void setInput(Item item)
    {
        _input = item;
    }

    public void TriggerOption1()
    {
        _dialogueHandlerRef._selectedUtillity.TriggerOption1();
    }

    public void TriggerOption2()
    {
        _dialogueHandlerRef._selectedUtillity.TriggerOption2();
    }

    public void UnlockDialogue()
    {
        _dialogueLocked = false;
    }
}
