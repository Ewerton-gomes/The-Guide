using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objetivo;
    void Start()
    {
        
    }
    void Update()
    {
        if (GameManager.Instance.ChavePorao == true && SceneManager.GetActiveScene().name != "Porao")
        {
            objetivo.text = "V� at� o por�o";
        }
        if (SceneManager.GetActiveScene().name == "Porao")
        {
            objetivo.text = "Voc� chegou ao por�o, parab�ns, esse foi o desafio, pode sair agora ;-;";
        }
    }
}
