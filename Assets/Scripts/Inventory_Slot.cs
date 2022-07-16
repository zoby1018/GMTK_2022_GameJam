using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Slot : MonoBehaviour
{
    private Hotbar _hotbar;
    public Item _slottedItem;

    // Start is called before the first frame update
    void Start()
    {
        _hotbar = FindObjectOfType<Hotbar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckIfEmpty()
    {
        if(_slottedItem == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
