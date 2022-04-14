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
            objetivo.text = "Vá até o porão";
        }
        if (SceneManager.GetActiveScene().name == "Porao")
        {
            objetivo.text = "Você chegou ao porão, parabéns, esse foi o desafio, pode sair agora ;-;";
        }
    }
}
