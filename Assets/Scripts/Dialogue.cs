using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    private Item _input;
    private Item _output;
    private string _text;

    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private Transform _outputContainer;
    [SerializeField] private Transform _inputContainer;

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
        if (!pipeline)
        {
            _dialogueText.text = text;
            _outputContainer.localPosition = new Vector3(0, -100, 0);
            if(output != null)
            {
                Item item = Item.Instantiate(output);
                item.transform.SetParent(_outputContainer);
                item.transform.position = _outputContainer.transform.position;
                item.setStartingPosition(_outputContainer.transform.position);
            }
        }
        else if (pipeline)
        {

        }
    }
}
