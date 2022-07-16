using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public List<Item> _inventory = new List<Item>();
    [SerializeField]private Transform _inventoryContainer;

    [SerializeField] private Transform[] _inventorySlots;

    // Start is called before the first frame update
    void Start()
    {
        
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
