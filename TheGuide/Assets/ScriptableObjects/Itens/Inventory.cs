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
    
    public List<Item> items = new List<Item>();
    public void Add(Item item)
    {
        items.Add(item);
    }
    public void Remove(Item item)
    {
        items.Remove(item);
    }
}
