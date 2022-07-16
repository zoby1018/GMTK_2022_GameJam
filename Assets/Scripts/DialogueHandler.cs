using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{

    public Utillity _selectedUtillity;
    private GameObject _selectedDialogue;
    [SerializeField] GameObject _dialogueBackground;
    [SerializeField] public Dialogue _dialogueObject;
    [SerializeField] public PlayerData _playerRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelectedUitillity(Utillity utillity)
    {
        _selectedUtillity = utillity;
    }

    public void OpenDialogue(string dialogue, Item output, int mode)
    {
        _dialogueBackground.SetActive(true);
        _dialogueObject.gameObject.SetActive(true);
        _dialogueObject.UpdateDialogue(dialogue, output, mode);
    }

    public void CloseDialogue()
    {
        _dialogueBackground.SetActive(false);
        _dialogueObject.CloseDialogue();
    }
}
