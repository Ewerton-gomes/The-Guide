using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "Inventory/Item/Key")]
public class Key : Item
{
    public override void Use()
    {
        GameObject.Find("Ella").GetComponent<PlayerManager>().ChavePorao = true;
        GameManager.Instance.ChavePorao = true;
        GameManager.Instance.DesativaChavePorao();
    }
}
