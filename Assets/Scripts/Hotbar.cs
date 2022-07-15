using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private List<Item> _inventory = new List<Item>();
    [SerializeField]private Transform _inventoryContainer;

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
        if(_inventory.Count < 9)
        {
            _inventory.Add(item);
            item.transform.SetParent(_inventoryContainer);
        }


       
    }
}
