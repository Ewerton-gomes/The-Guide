using UnityEngine;
public class PickItem : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Inventory.Instance.Add(item);
        Debug.Log("Pegou "+item.name);
    }
}
