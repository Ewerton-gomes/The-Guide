using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagUI : MonoBehaviour
{
    [SerializeField] GameObject bagUI;
    [SerializeField] GameObject bag;
    Inventory inventory;
    public Transform itemsParent;
    InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangeCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            bagUI.SetActive(!bagUI.activeSelf);
            bag.SetActive(!bagUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
