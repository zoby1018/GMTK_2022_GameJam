using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private string _name;
    public string Name => _name;

    private Vector3 _startingPosition;

    public bool UsePointerDisplacement = true;
    private bool dragging = false;
    private Vector3 pointerDisplacement = Vector3.zero;
    private float zDisplacement;
    private bool _attemptingToAddToInventory;
    private Hotbar _hotbar;
    private Transform _inputBox;

    private bool _isInInventory;

    private DialogueHandler _dialogueHandlerRef;

    private bool _recentlyLeftHitbox;


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
        if (dragging)
        {

            Vector3 mousePos = MouseInWorldCoords();
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        }
    }


    private Vector3 MouseInWorldCoords()
    {
        var screenMousePos = Input.mousePosition;
        //Debug.Log(screenMousePos);
        screenMousePos.z = zDisplacement;
        return Camera.main.ScreenToWorldPoint(screenMousePos);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        zDisplacement = -Camera.main.transform.position.z + transform.position.z;
        pointerDisplacement = -transform.position + MouseInWorldCoords();
        GetComponent<Canvas>().overrideSorting = true;
        GetComponent<Canvas>().sortingOrder = 10;
    

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (dragging)
        {
            if (_attemptingToAddToInventory && _isInInventory == false)
            {
                if (!_hotbar._inventory.Contains(this))
                {
                    AddToHotBar();
                }
               
            }
            if(_attemptingToAddToInventory == false && _isInInventory == true && _inputBox != null)
            {
                transform.SetParent(_inputBox);
                setStartingPosition(_inputBox.transform.position);
                _hotbar.RemoveItem(this);
                _dialogueHandlerRef._dialogueObject.setInput(this);
                _isInInventory = false;

            }


            dragging = false;
            transform.position = _startingPosition;

        }
    }

    public void setStartingPosition(Vector3 pos)
    {
        _startingPosition = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hotbar")
        {
            if (!collision.GetComponent<Hotbar>()._inventory.Contains(this))
            {
                _attemptingToAddToInventory = true;
                _hotbar = collision.GetComponent<Hotbar>();
            }
            
        }
        if (collision.tag == "InputPipeline")
        {
            _inputBox = collision.transform;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Hotbar")
        {
            _attemptingToAddToInventory = false;
        }
        if(collision.tag == "InputPipeline")
        {
            if(_inputBox != null)
            {
                _inputBox = null;
            }
            if(collision != null)
            {
                collision.GetComponentInParent<Dialogue>().ClearInput();
            }
           

        }
    }

    public void AddToHotBar()
    {
        _hotbar.AddItemToInventory(this);
        _isInInventory = true;
        _attemptingToAddToInventory = false;
        _dialogueHandlerRef._selectedUtillity.RemoveStock();
        _inputBox = null;
    }

    public void CheckIfInInput()
    {
        if(_isInInventory == false)
        {
            AddToHotBar();
        }
    }
}
