using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public List<Item> _inventory = new List<Item>();
    [SerializeField]private Transform _inventoryContainer;

    [SerializeField] private Transform[] _inventorySlots;

    PlayerData _player;

    // Start is called before the first frame update

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
       _player = FindObjectOfType<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void AddItemToInventory(Item item)
    {
        if(_inventory.Count < 7)
        {
            _inventory.Add(item);
            item.transform.SetParent(_inventorySlots[_inventory.IndexOf(item)]);
            item.transform.position = _inventorySlots[_inventory.IndexOf(item)].position;
            item.setStartingPosition(_inventorySlots[_inventory.IndexOf(item)].position);

        }

    }

    public void LoadInventory(Item item)
    {
        if (_inventory.Count < 7)
        {
            _inventory.Add(item);
            item.transform.SetParent(_inventorySlots[_inventory.IndexOf(item)]);
            item.transform.position = _inventorySlots[_inventory.IndexOf(item)].position;
            item.setStartingPosition(_inventorySlots[_inventory.IndexOf(item)].position);
            item._attemptingToAddToInventory = false;
            item._isInInventory = true;
            item._inputBox = null;
            item._hotbar = this;
        }
    }

    public void CheckInventory()
    {
        Debug.Log("Check Inventory Called");
        for(int i=0; i<_inventory.Count; i++)
        {
            _inventory[i].setStartingPosition(transform.parent.position);
        }
    }

    public void PrepInventoryForLoad()
    {
        for(int i=0; i<_inventory.Count; i++)
        {
            _player._inventory.Add(_inventory[i]);
            _inventory[i].transform.SetParent(_player.transform);
        }
    }

    public void RemoveItem(Item item)
    {
        if (_inventory.Contains(item))
        {
            _inventory.Remove(item);
        }
       
    }

    public void CheckForEmpySlot()
    {
        
    }
}
