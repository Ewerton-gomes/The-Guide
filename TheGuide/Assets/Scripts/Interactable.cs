using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] float radius = 3f;
    [SerializeField] Transform player;
    [SerializeField] Transform itemTransform;
    bool interacted = false;

    public virtual void Interact()
    {
        Debug.Log("Pegou Item");
    }
    void Start()
    {
        
        if (itemTransform == null)
        {
            itemTransform = transform;
        }
    }
    void Update()
    {
        if (player == null)
        {
            player = GameManager.Instance.Search("Ella").gameObject.transform;
        }
        if (GameObject.Find(this.name))
        {
            IsClose();
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(itemTransform.position, radius);
    }

    void IsClose()
    {
        if (Vector3.Distance(player.position,itemTransform.position) <= radius && !interacted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
                interacted = true;
            }
        }
    }
}
