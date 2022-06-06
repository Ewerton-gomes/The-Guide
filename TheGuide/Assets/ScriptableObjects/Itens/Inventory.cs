using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    #region Singleton
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Mais de um inventario meu bom, resolve isso ai");
            return;
        }
        Instance = this;
    }
    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;
    public int space = 5;
    public List<Item> items = new List<Item>();
    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room");
            return false;
        }
        items.Add(item);
        
        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
        return true;
    }
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
    }
}
