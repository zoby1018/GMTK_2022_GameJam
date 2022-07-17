using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{

    private float _currentHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private Item _battery;
    //[SerializeField] private Image _fillImage;
    public List<Item> _inventory = new List<Item>();
    // Start is called before the first frame update


    public bool _mouseEnding;
    public bool _nullEnding = true;

    public string[] ending_dialogue = 
    {

        "Ending 01: You did your job with no questions or complaints. You continued to do so day in and day out never wondering" +
            "If there was more. Why did you do it? Whats the point in aksing unsolvable questions.",

        "Ending 02: You gave a mouse a cookie and now you have a friend for life."

        

    };

    DialogueHandler _dialogueHandlerRef;

    Hotbar _hotbar;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
       
    }

    void Start()
    {
        _currentHealth = _maxHealth;
        _dialogueHandlerRef = FindObjectOfType<DialogueHandler>();
        _hotbar = FindObjectOfType<Hotbar>();


    }

    private void OnLevelWasLoaded(int level)
    {
        _hotbar = FindObjectOfType<Hotbar>();
        _dialogueHandlerRef = FindObjectOfType<DialogueHandler>();
      

        if(_dialogueHandlerRef == null)
        {
            PurgeItems();
        }
        else
        {

            _dialogueHandlerRef._playerRef = this;

            for (int i = 0; i < _inventory.Count; i++)
            {
                _inventory[i].UpdateDialogueHandler(_dialogueHandlerRef);
                _hotbar.LoadInventory(_inventory[i]);
            }
        }

        

        _inventory.Clear();
        _dialogueHandlerRef._dialogueObject.UnlockDialogue();
        //_hotbar.CheckInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if(_dialogueHandlerRef != null)
        {
            _dialogueHandlerRef._fillImage.fillAmount = Mathf.Lerp(_dialogueHandlerRef._fillImage.fillAmount, _currentHealth / _maxHealth, Time.deltaTime * 10f);
        }
       
    }


    public void TakeDamage(float damage)
    {
        Debug.Log("Damage taken");
        _currentHealth -= damage;

        if(_currentHealth <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }


    public int SetEnding()
    {
        if (_mouseEnding)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public void PurgeItems()
    {
        for(int i=0; i<_inventory.Count; i++)
        {
            Destroy(_inventory[i].gameObject);
        }
    }
}
