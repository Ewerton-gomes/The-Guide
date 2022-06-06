using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        icon.preserveAspect = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        icon.preserveAspect = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
