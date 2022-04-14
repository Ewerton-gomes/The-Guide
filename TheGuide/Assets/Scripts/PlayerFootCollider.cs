using UnityEngine;
using TMPro;

public class PlayerFootCollider : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI interactTxt;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Interact"))
        {
            interactTxt.gameObject.SetActive(true);
            interactTxt.text = "(E) para " + collision.GetComponent<InteractTxt>().texto;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactTxt.gameObject.SetActive(false);
    }
}
