using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")] 
public class Item : ScriptableObject
{
    new public string name = "Item";
    public Sprite icon = null;
    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
